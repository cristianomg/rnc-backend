using _4lab.Administration.Application.DTOs;
using _4lab.Administration.Domain.Interfaces;
using _4lab.Infrastructure.Authorization;
using _4lab.Infrastructure.Smtp;
using _4Lab.Administration.Domain.Models;
using _4Lab.Core.DomainObjects.Extensions;
using _4Lab.Infrastructure.Authorization;
using AutoMapper;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _4lab.Administration.Application.Service
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly ICryptograph _cryptograph;
        private readonly IEmailSender _senderEmail;
        private readonly IMapper _mapper;

        public UserAppService(IUserRepository userRepository, IUserAuthRepository userAuthRepository, ICryptograph cryptograph,
                              IEmailSender senderEmail, IMapper mapper)
        {
            _userRepository = userRepository;
            _userAuthRepository = userAuthRepository;
            _cryptograph = cryptograph;
            _senderEmail = senderEmail;
            _mapper = mapper;
        }

        public async Task<User> GetUserByIdWithInclude(int id, params string[] includes)
        {
            var user = await _userRepository.GetByIdWithInclude(id, includes);
            return user;
        }

        public async Task<UserAuth> GetUserAuthById(int id)
        {
            return await _userAuthRepository.GetById(id);
        }

        public async Task<IQueryable<DtoUserActive>> GetAllDontActive()
        {
            var users = await _userRepository.GetAllDontActive();
            return _mapper.ProjectTo<DtoUserActive>(users);
        }

        public async Task<DtoUserResponse> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return _mapper.Map<DtoUserResponse>(user);
        }

        public async Task<DtoUserResponse> ActiveUser(string email)
        {
            var user = await _userRepository.ActiveUser(email);
            return _mapper.Map<DtoUserResponse>(user);
        }

        public async Task DeleteUserByEmail(string email)
        {
            await _userRepository.DeleteUserByEmail(email);
        }

        public async Task<bool> ChangeName(int id, DtoChangeNameInput dtoChangeName)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                throw new Exception("Usuário não encontrado.");

            if (string.IsNullOrEmpty(dtoChangeName.NewName))
                throw new Exception("O nome não pode ser nulo.");

            user.Name = dtoChangeName.NewName;

            await _userRepository.Update(user);
            await _userRepository.SaveChanges();

            return true;
        }

        public async Task<bool> ChangePassword(DtoChangePassword dtoChangePassword)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                var user = await _userAuthRepository.GetByEmail(dtoChangePassword.Email);

                if (user == null)
                    throw new Exception("O email não foi encontrado.");

                if (!(_cryptograph.VerifyPassword(dtoChangePassword.OldPassword, user.Password)))
                    throw new Exception("Senha não é a correta");

                var newPassword = _cryptograph.EncryptPassword(dtoChangePassword.NewPassword);
                user.SetPassword(newPassword);

                await _userAuthRepository.Update(user);
                await _userAuthRepository.SaveChanges();

                scope.Complete();

                return true;
            }
            catch
            {
                scope.Dispose();
                throw new Exception("Não foi possível trocar a senha.");
            }
        }

        public async Task<DtoCreateAuthResponse> CreateAuth(DtoCreateAuthInput dtoCreateAuth)
        {
            var existingAuth = await _userAuthRepository.GetByEmail(dtoCreateAuth.Email);

            if (existingAuth != null && (_cryptograph.VerifyPassword(dtoCreateAuth.Password, existingAuth.Password)))
            {
                if (existingAuth.Active)
                {
                    var correctPassword = _cryptograph.VerifyPassword(dtoCreateAuth.Password, existingAuth.Password);

                    if (correctPassword)
                    {
                        var token = TokenService.GenerateToken(existingAuth.Id, existingAuth.User.Name, existingAuth.User.UserPermission.Name);

                        var user = new DtoUser
                        {
                            CompleteName = existingAuth.User.Name,
                            Email = existingAuth.Email,
                            Enrollment = existingAuth.User.Enrollment,
                            Setor = existingAuth.User.SetorId
                        };

                        var authResult = new DtoCreateAuthResponse { User = user, Token = token, Permission = existingAuth.User.UserPermissionId.GetDescription() };

                        return authResult;
                    }
                }

                throw new Exception("Cadastro ainda não foi aprovado.");
            }

            throw new Exception("Email ou senha invalidos.");
        }

        public async Task<bool> CreateUser(DtoCreateUserInput createUserInput)
        {
            var hasUserWithEmail = await _userAuthRepository.GetAll(x => x.Email == createUserInput.Email);

            if (hasUserWithEmail != null && hasUserWithEmail.Any())
                throw new Exception("O email já está em uso.");

            var hasEnrollment = await _userRepository
                .GetByEnrollment(createUserInput.Enrollment);

            if (hasEnrollment != null)
                throw new Exception("A matricula já está em uso.");

            if (!createUserInput.Password.Equals(createUserInput.ConfirmPassword))
                throw new Exception("As senhas não coincidem,");

            var password = _cryptograph.EncryptPassword(createUserInput.Password);

            var userAuth = new UserAuth(createUserInput.Email, password);
            var user = new User(createUserInput.CompleteName, createUserInput.Enrollment, createUserInput.Setor, createUserInput.UserPermission, userAuth)
            {
                Active = false
            };

            await _userRepository.Insert(user);
            await _userRepository.SaveChanges();

            return true;
        }

        public async Task<bool> Approved(string email)
        {
            try
            {
                var template = new StringBuilder();
                template.AppendLine("Olá, seu cadastro foi aprovado com sucesso.");
                template.AppendLine("Agora você poderá efetuar o login e se desfrutar com as funcionalidades do Rnc");
                template.AppendLine("");
                template.AppendLine("Atenciosamente, time do RNC");
                var subjectEmail = "Cadastro aprovado";

                await _senderEmail.SendEmail(email, template.ToString(), subjectEmail);
                return true;
            }
            catch
            {
                throw new Exception("Erro ao enviar email.");
            }
        }

        public async Task<bool> Disapproved(string email)
        {
            try
            {
                var template = new StringBuilder();
                template.AppendLine("Olá, seu cadastro infelizmente foi reprovado.");
                template.AppendLine("Você poderá realizar um novo cadastro, mas recomendamos que verifique com atenção os dados inseridos.");
                template.AppendLine("");
                template.AppendLine("Atenciosamente, time do RNC");

                var subjectEmail = "Cadastro reprovado";

                await _senderEmail.SendEmail(email, template.ToString(), subjectEmail);
                return true;
            }
            catch
            {
                throw new Exception("Erro ao enviar email.");
            }
        }


        public async Task<bool> RecoveryPassword(string email)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                var hasUserWithEmail = await _userAuthRepository.GetAllWithIncludes(nameof(UserAuth.User));

                var user = hasUserWithEmail.FirstOrDefault(x => x.Email == email);

                if (user == null)
                    throw new Exception("O email não foi encontrado.");

                var newPassword = RandomPassword();
                var password = _cryptograph.EncryptPassword(newPassword);

                user.SetPassword(password);

                await _userAuthRepository.Update(user);
                await _userAuthRepository.SaveChanges();

                await SendEmailToForgotpassword(email, user.User.Name, newPassword);

                scope.Complete();

                return true;
            }
            catch
            {
                scope.Dispose();
                throw new Exception("Erro ao enviar email.");
            }
        }

        private static string RandomPassword()
        {
            var ArrayAlph = "abcdefghijklm".ToCharArray();
            int tamanhoPass = 6;
            int tam = ArrayAlph.Length;
            string password = string.Empty;

            for (int i = 0; i < tamanhoPass; i++)
            {
                var random = new Random();
                int codigo = Convert.ToInt32(random.Next(0, tam - 1).ToString());
                password += ArrayAlph[codigo];
            }

            return password;
        }

        private async Task SendEmailToForgotpassword(string email, string name, string password)
        {
            var template = new StringBuilder();

            template.AppendLine($"Olá <strong>{name}</strong>");
            template.AppendLine("<p>Recebemos uma solicitação para redefinir sua senha do 4Labs.</p>");
            template.AppendLine("</br>");
            template.AppendLine($"<p>Aqui está sua nova senha: <strong>{password}</strong></p>");
            template.AppendLine("</br>");
            template.AppendLine("<p>Recomendamos que você troque essa senha pois ela é provisória.</p>");
            template.AppendLine("</br>");
            template.AppendLine("<p>Atenciosamente, equipe 4Labs.</p>");

            var subjectEmail = "Envio de senha provisória";

            await _senderEmail.SendEmail(email, template.ToString(), subjectEmail, isHtml: true);
        }
    }
}
