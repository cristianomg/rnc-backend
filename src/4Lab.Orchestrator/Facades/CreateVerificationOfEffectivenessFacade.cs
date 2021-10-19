using _4lab.Administration.Application.Service;
using _4lab.Occurrences.Application.Service;
using _4Lab.Occurrences.Application.DTOs;
using _4Lab.Orchestrator.Interfaces;
using System;
using System.Threading.Tasks;

namespace _4Lab.Orchestrator.Facades
{
    public class CreateVerificationOfEffectivenessFacade : ICreateVerificationOfEffectivenessFacade
    {
        private readonly IOccurrenceAppService _occurrenceAppService;
        private readonly IUserAppService _userAppService;
        private readonly ISetorAppService _setorAppService;
        public CreateVerificationOfEffectivenessFacade(IOccurrenceAppService occurrenceAppService
                                                     , IUserAppService userAppService
                                                     , ISetorAppService setorAppService)
        {
            _occurrenceAppService = occurrenceAppService;
            _userAppService = userAppService;
            _setorAppService = setorAppService;
        }
        public async Task<bool> Execute(DtoVerificationOfEffectivenessInput analysis)
        {
            var occurrenceRegister = await _occurrenceAppService.GetOccurrenceRegisterById(analysis.OccurrenceRegisterId);

            if (occurrenceRegister is null)
                throw new Exception("Registro de occorrencia não encontrado.");

            var user = await _userAppService.GetUserByIdWithInclude(analysis.UserId);

            if (user.Id != occurrenceRegister.UserId)
                throw new Exception("Usuário sem permissão para fazer a verificação de eficácia.");

            return await _occurrenceAppService.VerifyEffectiveness(analysis);
        }
    }
}
