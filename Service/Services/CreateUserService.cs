using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CreateUserService : AbstractService, ICreateUserService
    {
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICryptograph _cryptograph;
        public CreateUserService(IUserAuthRepository userAuthRepository,
                                 IUserRepository userRepository,
                                 ICryptograph cryptograph)
        {
            _userAuthRepository = userAuthRepository;
            _userRepository = userRepository;
            _cryptograph = cryptograph;
        }
        /// <summary>
        /// Método responsável por criar o usuário
        /// </summary>
        /// <param name="createUserInput"></param>
        /// <returns></returns>
        public async Task<ResponseService> Execute(DtoCreateUserInput createUserInput)
        {
            var hasUserWithEmail = await _userAuthRepository
                .GetAll(x => x.Email == createUserInput.Email);

            if (hasUserWithEmail != null && hasUserWithEmail.Any())
                return GenerateErroServiceResponse("O email já está em uso.");

            var hasEnrollment = await _userRepository
                .GetByEnrollment(createUserInput.Enrollment);

            if (hasEnrollment != null)
                return GenerateErroServiceResponse("A matricula já está em uso.");

            if (createUserInput.Password != createUserInput.ConfirmPassword)
                return GenerateErroServiceResponse("As senhas não coincidem,");

            var newUser = await _userRepository.Insert(new User 
            {
                Name = createUserInput.CompleteName,
                UserAuth = new UserAuth
                {
                    Email = createUserInput.Email,
                    Password = _cryptograph.EncryptPassword(createUserInput.Password)
                },
                Enrollment = createUserInput.Enrollment,
                Setor = createUserInput.Setor,
                Crbm = createUserInput.Crbm,
                UserPermissionId = createUserInput.UserPermission,
            });

            await _userRepository.SaveChanges();

            return GenerateSuccessServiceResponse(HttpStatusCode.Created);
        }
    }
}
