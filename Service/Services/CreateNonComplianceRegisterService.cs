using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;

namespace Service.Services
{
    public class CreateNonComplianceRegisterService : AbstractService, ICreateNonComplianceRegisterService
    {
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly INonComplianceRepository _nonComplianceRepository;
        private readonly IMapper _mapper;
        public CreateNonComplianceRegisterService(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                                                  INonComplianceRepository nonComplianceRepository,
                                                  IMapper mapper)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _nonComplianceRepository = nonComplianceRepository;
            _mapper = mapper;
        }

        public async Task<ResponseService> Execute(DtoNonComplianceRegisterInput nonCompliance)
        {
            if (nonCompliance.RegisterDate == DateTime.MinValue)
                return GenerateErroServiceResponse<NonComplianceRegister>("A data precisa ser informada.");
            if (nonCompliance.RegisterHour == null)
                return GenerateErroServiceResponse<NonComplianceRegister>("O horário que ocorreu a não conformidade precisa ser informada.");

            if (string.IsNullOrEmpty(nonCompliance.ImmediateAction))
                return GenerateErroServiceResponse<NonComplianceRegister>("A ação imediata não pode ser vazia.");

            using (var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var notExistingNonCompliance = await CreateNewNonCompliance(nonCompliance.UserName, nonCompliance.NonCompliances.Where(x => !x.Id.HasValue));

                    var existingNonCompliance = await CheckExistingNonCompliances(nonCompliance.NonCompliances.Where(x => x.Id.HasValue));

                    if (!existingNonCompliance.Success)
                        return GenerateErroServiceResponse(existingNonCompliance.Message);

                    var allNonCompliances = existingNonCompliance.Value.Union(notExistingNonCompliance);
                    List<Archives> archives = new();
                    archives = _mapper.Map<List<Archives>>(nonCompliance.Archives);

                    var entity = await _nonComplianceRegisterRepository.Insert(new NonComplianceRegister
                    {
                        UserId = nonCompliance.UserId,
                        ImmediateAction = nonCompliance.ImmediateAction,
                        MoreInformation = nonCompliance.MoreInformation,
                        PeopleInvolved = nonCompliance.PeopleInvolved,
                        RegisterDate = nonCompliance.RegisterDate,
                        RegisterHour = nonCompliance.RegisterHour,
                        SetorId = nonCompliance.Setor,
                        CreatedAt = DateTime.Now,
                        NonCompliances = allNonCompliances.ToList(),
                        CreatedBy = nonCompliance.UserName,
                        Archives = archives
                    });

                    await _nonComplianceRegisterRepository.SaveChanges();

                    scope.Complete();

                    return GenerateSuccessServiceResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    scope.Dispose();
                    return GenerateErroServiceResponse("Erro ao criar novo registro de não conformidades.");
                }
            }

        }

        private async Task<List<NonCompliance>> CreateNewNonCompliance(string creationUserName, IEnumerable<DtoNonCompliance> nonCompliances)
        {
            if (!nonCompliances.Any())
                return new List<NonCompliance>();

            var newNonCompliances = new List<NonCompliance>();

            foreach (var nc in nonCompliances)
            {
                var nonCompliance = await _nonComplianceRepository.Insert(new NonCompliance
                {
                    Active = false,
                    Description = nc.Description,
                    TypeNonComplianceId = nc.TypeNonComplianceId,
                    CreatedAt = DateTime.Now,
                    CreatedBy = creationUserName

                });

                await _nonComplianceRepository.SaveChanges();

                newNonCompliances.Add(nonCompliance);
            }


            return newNonCompliances;
        }
        private async Task<ResponseService<List<NonCompliance>>> CheckExistingNonCompliances(IEnumerable<DtoNonCompliance> nonCompliances)
        {
            var ncs = new List<NonCompliance>();

            foreach (var nc in nonCompliances)
            {
                var hasNonCompliance = await _nonComplianceRepository.GetById(nc.Id.Value);

                if (hasNonCompliance == null)
                    return GenerateErroServiceResponse<List<NonCompliance>>($"Não foi encontrado a não conformidade com descrição: {nc.Description}.");

                ncs.Add(hasNonCompliance);
            }

            return GenerateSuccessServiceResponse(ncs);
        }
    }
}
