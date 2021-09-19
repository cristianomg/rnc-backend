using _4lab.Administration.Application.DTOs;
using _4lab.Administration.Domain.Interfaces;
using _4lab.Infrastructure.Authorization;
using _4Lab.Administration.Domain.Models;
using _4Lab.Core.DomainObjects.Extensions;
using _4Lab.Infrastructure.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace _4lab.Administration.Application.Service
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly ICryptograph _cryptograph;

        public UserAppService(IUserRepository userRepository, IUserAuthRepository userAuthRepository, ICryptograph cryptograph)
        {
            _userRepository = userRepository;
            _userAuthRepository = userAuthRepository;
            _cryptograph = cryptograph;
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
            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
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


        public async Task<bool> RecoveryPassword(string email)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var hasUserWithEmail = await _userAuthRepository
                        .GetAllWithIncludes(nameof(UserAuth.User));

                    var user = hasUserWithEmail.FirstOrDefault(x => x.Email == email);

                    if (user == null)
                        throw new Exception("O email não foi encontrado.");

                    var newPassword = RandomPassword();

                    var password = _cryptograph.EncryptPassword(newPassword);
                    user.SetPassword(password);

                    await _userAuthRepository.Update(user);

                    await _userAuthRepository.SaveChanges();

                    await _esqueciSenha.SendEmailToForgotpassword(email, user.User.Name, newPassword);

                    scope.Complete();

                    return true;
                }
                catch
                {
                    scope.Dispose();
                    throw new Exception("Erro ao enviar email.");
                }
            }
        }

        private string RandomPassword()
        {
            var ArrayAlph = "abcdefghijklm".ToCharArray();
            int tamanhoPass = 6;
            int tam = ArrayAlph.Length;
            string password = string.Empty;
            for (int i = 0; i < tamanhoPass; i++)
            {
                Random random = new Random();
                int codigo = Convert.ToInt32(random.Next(0, tam - 1).ToString());

                password += ArrayAlph[codigo];
            }

            return password;
        }
    }
}
