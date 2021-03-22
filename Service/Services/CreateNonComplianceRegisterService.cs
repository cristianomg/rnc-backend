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
        public CreateNonComplianceRegisterService(INonComplianceRegisterRepository nonComplianceRegisterRepository)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
        }

        public async Task<ResponseService<NonComplianceRegister>> Execute(int userId, DtoNonComplianceRegisterInput nonCompliance)
        {
            var entity = await _nonComplianceRegisterRepository.Insert(new NonComplianceRegister
            {
                UserId = userId,
                ImmediateAction = nonCompliance.ImmediateAction,
                MoreInformation = nonCompliance.MoreInformation,
                NonComplianceId = nonCompliance.NonComplianceId,
                PeopleInvolved = nonCompliance.PeopleInvolved,
                RegisterDate = nonCompliance.RegisterDate,
                RegisterHour = nonCompliance.RegisterHour,
                Setor = nonCompliance.Setor,
                CreatedAt = DateTime.Now
            });
            await _nonComplianceRegisterRepository.SaveChanges();

            return GenerateSuccessServiceResponse(entity, HttpStatusCode.Created);
        }
    }
}
