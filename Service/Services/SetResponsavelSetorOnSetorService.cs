using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using Domain.ValueObjects;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SetResponsavelSetorOnSetorService : AbstractService, ISetResponsavelSetorOnSetorService
    {
        private readonly ISetorRepository _setorRepository;
        private readonly IUserRepository _userRepository;

        public SetResponsavelSetorOnSetorService(ISetorRepository setorRepository, IUserRepository userRepository)
        {
            _setorRepository = setorRepository;
            _userRepository = userRepository;
        }

        public async Task<ResponseService> Execute(DtoSetResponsavelSetor createSetor)
        {

            var setor = await _setorRepository.GetById(createSetor.SetorId);

            if (setor == null)
                return GenerateErroServiceResponse("Setor não encontrado.");

            var user = await _userRepository.GetByEmail(createSetor.UserEmail);

            if (user == null)
                return GenerateErroServiceResponse("Usuário não encontrado.");

            if (user.UserPermissionId != UserPermissionType.ResponsibleFS)
                return GenerateErroServiceResponse("Usuário não é um responsável pelo setor.");

            setor.ResponsavelDoSetorId = user.Id;
            setor.UpdatedBy = createSetor.UserName;

            await _setorRepository.Update(setor);

            await _setorRepository.SaveChanges();

            return GenerateSuccessServiceResponse();
        }
    }
}
