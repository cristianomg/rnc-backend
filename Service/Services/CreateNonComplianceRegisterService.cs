using AutoMapper;
using _4lab.Ocurrences.Application.DTOs;
using Domain.Entities;
using Domain.Enums;
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
                return GenerateErroServiceResponse<NonComplianceRegister>
                    ("A data precisa ser informada.");
            if (nonCompliance.RegisterHour == null)
                return GenerateErroServiceResponse<NonComplianceRegister>
                    ("O horário que ocorreu a não conformidade precisa ser informada.");

            if (string.IsNullOrEmpty(nonCompliance.ImmediateAction))
                return GenerateErroServiceResponse<NonComplianceRegister>
                    ("A ação imediata não pode ser vazia.");

            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                var auxArchives = nonCompliance.NonCompliances?
                        .SelectMany(x => x.Archives).ToList();
                var hasArchives = auxArchives != null && auxArchives.Any();

                if (hasArchives)
                    auxArchives
                        .Select(CreateObjectKeyToArchive)
                        .ToList();

                try
                {
                    var notExistingNonCompliance = await CreateNewNonCompliance
                                                      (
                                                        nonCompliance.UserName,
                                                        nonCompliance.NonCompliances
                                                            .Where(x => !x.Id.HasValue)
                                                      );

                    var existingNonCompliance = await CheckExistingNonCompliances
                                                      (
                                                        nonCompliance.NonCompliances
                                                           .Where(x => x.Id.HasValue)
                                                      );

                    if (!existingNonCompliance.Success)
                        return GenerateErroServiceResponse(existingNonCompliance.Message);

                    var allNonCompliances = existingNonCompliance.Value
                                                  .Union(notExistingNonCompliance);

                    var entity = await _nonComplianceRegisterRepository
                                                  .Insert(new NonComplianceRegister
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
                        OcurrencePendency = OcurrencePendency.RootCauseAnalysisAndActionPlan,
                        OccurrenceClassificationId = nonCompliance.OccurrenceClassification
                    });

                    await _nonComplianceRegisterRepository.SaveChanges();

                    await FillArchiveToNonCompliances(auxArchives,
                                                entity,
                                                nonCompliance);

                    scope.Complete();

                    return GenerateSuccessServiceResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    await DeleteFiles(nonCompliance.NonCompliances?
                                      .SelectMany(x => x.Archives)
                                      .ToList()
                                     );
                    Console.Write(ex);
                    scope.Dispose();
                    return GenerateErroServiceResponse("Erro ao criar novo registro de não conformidades.");
                }

            }
        }
        private async Task FillArchiveToNonCompliances(List<DtoCreateArchive> auxArchives,
                                                       NonComplianceRegister nonComplianceRegister,
                                                       DtoNonComplianceRegisterInput dtoNonCompliance)
        {

            var archives = auxArchives.Any() ? await UploadFiles(auxArchives) : null;

            foreach (var item in nonComplianceRegister.NonCompliances)
            {
                var _nonCompliance = dtoNonCompliance.NonCompliances.FirstOrDefault(x => x.Description == item.Description);

                if (_nonCompliance != null)
                {
                    foreach (var a in _nonCompliance.Archives)
                    {
                        var archive = archives.FirstOrDefault(x => x.Key == a.FileName);
                        archive.NonComplianceId = item.Id;
                        archive.NonComplianceRegisterId = nonComplianceRegister.Id;

                        item.Archives.Add(archive);
                    }
                }
            }

            await _nonComplianceRegisterRepository.Update(nonComplianceRegister);

            await _nonComplianceRegisterRepository.SaveChanges();
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
            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream(Convert.FromBase64String(file.File)))
                {
                    var objectKey = file.FileName;
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