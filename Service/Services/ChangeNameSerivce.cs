using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ChangeNameSerivce : AbstractService, IChangeNameService
    {
        private readonly IUserRepository _userRepository;
        public ChangeNameSerivce(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseService> Execute(int id, DtoChangeNameInput dtoChangeName)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                return GenerateErroServiceResponse("Usuário não encontrado.");

            if (string.IsNullOrEmpty(dtoChangeName.NewName))
                return GenerateErroServiceResponse("O nome não pode ser nulo.");

            user.Name = dtoChangeName.NewName;

            await _userRepository.Update(user);

            await _userRepository.SaveChanges();

            return GenerateSuccessServiceResponse();
        }
    }
}
