using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using System.Threading.Tasks;
using System.Transactions;

namespace Service.Services
{
    public class ChangePasswordService : AbstractService, IChangePasswordService
    {
        private readonly IUserAuthRepository _userAuthRepository;
        private readonly ICryptograph _cryptograph;
        public ChangePasswordService(IUserAuthRepository userAuthRepository, ICryptograph cryptograph)
        {
            _userAuthRepository = userAuthRepository;
            _cryptograph = cryptograph;
        }
        public async Task<ResponseService> Execute(DtoChangePassword dtoChangePassword)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var user = await _userAuthRepository.GetByEmail(dtoChangePassword.Email);

                    if (user == null)
                        return GenerateErroServiceResponse("O email não foi encontrado.");
                    if (!(_cryptograph.VerifyPassword(dtoChangePassword.OldPassword, user.Password)))
                        return GenerateErroServiceResponse("Senha não é a correta");

                    user.Password = _cryptograph.EncryptPassword(dtoChangePassword.NewPassword);

                    await _userAuthRepository.Update(user);

                    await _userAuthRepository.SaveChanges();

                    scope.Complete();

                    return GenerateSuccessServiceResponse();
                }
                catch
                {
                    scope.Dispose();
                    return GenerateErroServiceResponse("Não foi possível trocar a senha.");
                }
            }
        }
    }
}
