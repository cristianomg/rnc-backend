using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IStorageService _storageService;
        public CreateNonComplianceRegisterService(INonComplianceRegisterRepository nonComplianceRegisterRepository,
                                                  INonComplianceRepository nonComplianceRepository,
                                                  IMapper mapper,
                                                  IStorageService storageService)
        {
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _nonComplianceRepository = nonComplianceRepository;
            _mapper = mapper;
            _storageService = storageService;
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
                nonCompliance.Archives.Select(CreateObjectKeyToArchive);

                try
                {
                    var notExistingNonCompliance = await CreateNewNonCompliance(nonCompliance.UserName, nonCompliance.NonCompliances.Where(x => !x.Id.HasValue));

                    var existingNonCompliance = await CheckExistingNonCompliances(nonCompliance.NonCompliances.Where(x => x.Id.HasValue));

                    if (!existingNonCompliance.Success)
                        return GenerateErroServiceResponse(existingNonCompliance.Message);

                    var allNonCompliances = existingNonCompliance.Value.Union(notExistingNonCompliance);

                    var archives = await UploadFiles(nonCompliance.Archives);

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
                        Archives = archives.Select(x=>AddAttributesToArchive(x, nonCompliance)).ToList()
                    });

                    await _nonComplianceRegisterRepository.SaveChanges();

                    scope.Complete();

                    return GenerateSuccessServiceResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    DeleteFiles(nonCompliance.Archives);
                    Console.Write(ex);
                    scope.Dispose();
                    return GenerateErroServiceResponse("Erro ao criar novo registro de não conformidades.");
                }
            }

        }

        private async Task DeleteFiles(List<DtoCreateArchive> files)
        {
            foreach (var item in files)
            {
                await _storageService.DeleteFileAsync(item.FileName);
            }
        }

        private async Task<IEnumerable<Archive>> UploadFiles(List<DtoCreateArchive> files)
        {
            var archives = new List<Archive>();
            foreach(var file in files)
            {
                using(var memoryStream = new MemoryStream(Convert.FromBase64String(file.File)))
                {
                    var objectKey = $"{file.FileName}-{Guid.NewGuid()}";
                    await _storageService.UploadFileAsync(objectKey, memoryStream);

                    archives.Add(new Archive
                    {
                        Key = objectKey,
                    });
                }
            }
            return archives;
        }

        private DtoCreateArchive CreateObjectKeyToArchive(DtoCreateArchive dto)
        {
            dto.FileName = $"{dto.FileName}-{Guid.NewGuid()}";
            return dto;
        }

        private Archive AddAttributesToArchive(Archive archive, DtoNonComplianceRegisterInput nonCompliance)
        {
            archive.CreatedBy = nonCompliance.UserName;

            return archive;
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
