using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Models.Helps;

namespace Service.Services
{
    public class CreateNonComplianceRegisterService : AbstractService, ICreateNonComplianceRegisterService
    {
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly INonComplianceRepository _nonComplianceRepository;
        public CreateNonComplianceRegisterService(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                                                  INonComplianceRepository nonComplianceRepository)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _nonComplianceRepository = nonComplianceRepository;
        }

        public async Task<ResponseService<NonComplianceRegister>> Execute(int userId, DtoNonComplianceRegisterInput nonCompliance)
        {
            if (nonCompliance.RegisterDate == DateTime.MinValue)
                return GenerateErroServiceResponse<NonComplianceRegister>("A data precisa ser informada.");
            if (nonCompliance.RegisterHour == null)
                return GenerateErroServiceResponse<NonComplianceRegister>("O horário que ocorreu a não conformidade precisa ser informada.");

            var hasNonCompliance = await _nonComplianceRepository.GetById(nonCompliance.NonComplianceId);

            if (hasNonCompliance == null)
                return GenerateErroServiceResponse<NonComplianceRegister>("Não foi encontrado a não conformidade.");

            var entity = await _nonComplianceRegisterRepository.Insert(new NonComplianceRegister
            {
                UserId = userId,
                NonCompliance = hasNonCompliance,
                ImmediateAction = nonCompliance.ImmediateAction,
                MoreInformation = nonCompliance.MoreInformation,
                NonComplianceId = nonCompliance.NonComplianceId,
                PeopleInvolved = nonCompliance.PeopleInvolved,
                RegisterDate = nonCompliance.RegisterDate,
                RegisterHour = nonCompliance.RegisterHour,
                SetorId = nonCompliance.Setor,
                CreatedAt = DateTime.Now
            });
            await _nonComplianceRegisterRepository.SaveChanges();

            return GenerateSuccessServiceResponse(entity, HttpStatusCode.Created);
        }
    }
}
