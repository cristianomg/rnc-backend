using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SetSupervisorOnSetorService : AbstractService , ISetSupervisorOnSetorService
    {
        private readonly ISetorRepository _setorRepository;
        private readonly IUserRepository _userRepository;

        public SetSupervisorOnSetorService(ISetorRepository setorRepository, IUserRepository userRepository) 
        {
            _setorRepository = setorRepository;
            _userRepository = userRepository;
        }

        public async Task<ResponseService> Execute(DtoSetSupervisor createSetor) 
        {

            var setor = await _setorRepository.GetById(createSetor.SetorId);

            if (setor == null)
                return GenerateErroServiceResponse("Setor não encontrado.");

            var user = await _userRepository.GetByEmail(createSetor.UserEmail);

            if (user == null)
                return GenerateErroServiceResponse("Usuário não encontrado.");

            if (user.UserPermissionId != UserPermissionType.Supervisor)
                return GenerateErroServiceResponse("Usuário não é um supervisor.");

            setor.SupervisorId = user.Id;

            await _setorRepository.Update(setor);

            await _setorRepository.SaveChanges();

            return GenerateSuccessServiceResponse();
        }
    }
}
