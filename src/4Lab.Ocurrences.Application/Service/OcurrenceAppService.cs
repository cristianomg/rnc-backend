﻿using _4lab.Infrastructure.Storage;
using _4lab.Ocurrences.Application.DTOs;
using _4lab.Ocurrences.Domain.Interfaces;
using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Infrastructure.Charts;
using _4Lab.Infrastructure.Render.Html;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace _4lab.Ocurrences.Application.Service
{
    public class OcurrenceAppService : IOcurrenceAppService
    {
        private readonly IMapper _mapper;
        private readonly IActionPlainRepository _actionPlainRepository;
        private readonly IActionPlainQuestionRepository _actionPlainQuestionRepository;
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly INonComplianceRepository _nonComplianceRepository;
        private readonly IRootCauseAnalysisRepository _analyzeRootCauseRepository;
        private readonly IRazorRender _razorRender;

        public OcurrenceAppService(IActionPlainRepository actionPlainRepository
                                   , IActionPlainQuestionRepository actionPlainQuestionRepository
                                   , IMapper mapper
                                   , INonComplianceRegisterRepository nonComplianceRegisterRepository
                                   , INonComplianceRepository nonComplianceRepository
                                   , IStorageService storageService
                                   , IRootCauseAnalysisRepository analyzeRootCauseRepository
                                   , IRazorRender razorRender)
        {
            _actionPlainRepository = actionPlainRepository;
            _actionPlainQuestionRepository = actionPlainQuestionRepository;
            _mapper = mapper;
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _nonComplianceRepository = nonComplianceRepository;
            _analyzeRootCauseRepository = analyzeRootCauseRepository;
            _razorRender = razorRender;
        }

        public async Task<bool> CreateActionPlain(DtoCreateActionPlainInput dto)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                var hasActionPlainWithName = await _actionPlainRepository.GetAll(x => x.Name.ToLower() == dto.Name.ToLower());
                if (hasActionPlainWithName.FirstOrDefault() != null)
                    throw new Exception("Já existe um plano de ação com esse nome.");

                var questions = dto.Questions
                      .Select(x => new ActionPlainQuestion
                      {
                          Value = x.Value,
                          CreatedAt = DateTime.Now,
                          Active = true,
                          CreatedBy = dto.UserName
                      }).ToList();

                var actionPlain = new ActionPlain
                {
                    Name = dto.Name,
                    Active = true,
                    CreatedAt = DateTime.Now,
                    Questions = questions,
                    CreatedBy = dto.UserName
                };

                actionPlain = await _actionPlainRepository.Insert(actionPlain);

                await _actionPlainRepository.SaveChanges();
                actionPlain.Questions = await _actionPlainQuestionRepository.GetAll(x => x.ActionPlainId == actionPlain.Id);

                await _actionPlainRepository.SaveChanges();
                scope.Complete();

                return true;
            }
            catch (Exception)
            {
                scope.Dispose();
                throw new Exception("Erro ao criar plano de ação.");
            }
        }

        public async Task<bool> CreateNonComplianceRegister(DtoNonComplianceRegister nonCompliance)
        {
            if (nonCompliance.RegisterDate == DateTime.MinValue)
                throw new Exception("A data precisa ser informada.");

            if (nonCompliance.RegisterHour == null)
                throw new Exception("O horário que ocorreu a não conformidade precisa ser informada.");

            if (string.IsNullOrEmpty(nonCompliance.ImmediateAction))
                throw new Exception("A ação imediata não pode ser vazia.");

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                var notExistingNonCompliance = await CreateNewNonCompliance(nonCompliance.UserName, nonCompliance.NonCompliances.Where(x => !x.Id.HasValue));
                var existingNonCompliance = await CheckExistingNonCompliances(nonCompliance.NonCompliances.Where(x => x.Id.HasValue));

                if (!existingNonCompliance.Any())
                    throw new Exception("Não existe não conformidades.");

                var allNonCompliances = existingNonCompliance.Union(notExistingNonCompliance);

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

                scope.Complete();

                return true;
            }
            catch (Exception)
            {
                scope.Dispose();
                throw new Exception("Erro ao criar novo registro de não conformidades.");
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

        private async Task<List<NonCompliance>> CheckExistingNonCompliances(IEnumerable<DtoNonCompliance> nonCompliances)
        {
            var ncs = new List<NonCompliance>();

            foreach (var nc in nonCompliances)
            {
                var hasNonCompliance = await _nonComplianceRepository.GetById(nc.Id.Value);

                if (hasNonCompliance == null)
                    throw new Exception($"Não foi encontrado a não conformidade com descrição: {nc.Description}.");

                ncs.Add(hasNonCompliance);
            }

            return ncs;
        }

        public async Task<RootCauseAnalysis> CreateRootCauseAnalysis(DtoRootCauseAnalysisInput analyzeRootCause)
        {
            var nonComplianceRegister = await _nonComplianceRegisterRepository.GetByIdWithInclude(analyzeRootCause.NonComplianceRegisterId);

            if (nonComplianceRegister == null)
                throw new Exception("Registro de não conformidade não encontrado.");

            if (nonComplianceRegister.RootCauseAnalysis != null)
                throw new Exception("O registro de não conformidade já foi analisado.");

            using var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                var actionPlain = await _actionPlainRepository.GetByIdWithIncludes(analyzeRootCause.ActionPlain.Id.Value);

                if (actionPlain == null)
                    throw new Exception("O plano de ação não foi encontrado.");

                var responses = analyzeRootCause.ActionPlain.Questions.Select(x => new ActionPlainResponse
                {
                    Value = x.Response,
                    ActionPlainQuestionId = actionPlain.Questions.First(y => y.Value == x.Value).Id,
                    ActionPlainQuestion = actionPlain.Questions.First(y => y.Value == x.Value),
                    CreatedAt = DateTime.Now,
                    CreatedBy = analyzeRootCause.UserName,
                    Active = true,
                    ActionPlainId = actionPlain.Id,

                }).ToList();

                var fivewhats = new List<FiveWhat>();

                foreach (var what in analyzeRootCause.FiveWhat)
                {
                    fivewhats.Add(new FiveWhat
                    {
                        What = what.What,
                    });
                }

                var newAnalyzeRootCause = await _analyzeRootCauseRepository.Insert(new RootCauseAnalysis
                {
                    NonComplianceRegisterId = analyzeRootCause.NonComplianceRegisterId,
                    UserId = analyzeRootCause.UserId,
                    CreatedBy = analyzeRootCause.UserName,
                    FiveWhats = fivewhats,
                    ActionPlainId = actionPlain.Id,
                    ActionPlain = actionPlain,
                    ActionPlainResponses = responses
                });

                await _analyzeRootCauseRepository.SaveChanges();

                scoped.Complete();
                return newAnalyzeRootCause;
            }
            catch (Exception)
            {
                scoped.Dispose();
                throw new Exception("Erro ao inserir analise.");
            }
        }

        public async Task<DtoNonComplianceRegisterResponse> GetNonComplieanceRegisterById(Guid id)
        {
            var nonComplianceRegister = await _nonComplianceRegisterRepository.GetByIdWithInclude(id);
            var nonCompliance = _mapper.Map<DtoNonComplianceRegisterResponse>(nonComplianceRegister);

            return nonCompliance;
        }

        public async Task<byte[]> CreatePieChartWithNonComplianceRegister(SetorType setor, int month)
        {
            var nonComplianceGroup = await _nonComplianceRegisterRepository.GetGroupBySetor(setor, month);
            var nonComplianceGroupList = nonComplianceGroup.ToList();

            var chartData = new Dictionary<string, double>();

            nonComplianceGroupList.ForEach(x => chartData.Add(x.NonCompliance, x.Quantity));

            var chart = ChartGenerator.GeneratePieChart(chartData);

            return chart;
        }

        public async Task<string> CreateNonComplianceRegisterReport(Guid nonComplianceRegisterId)
        {
            var nonComplianceRegister = await _nonComplianceRegisterRepository.GetByIdForReport(nonComplianceRegisterId);

            if (nonComplianceRegister == null)
                throw new Exception("Registro de não conformidade não encontrado.");

            if (!nonComplianceRegister.HasRootCauseAnalysis())
                throw new Exception("Resgistro ainda não possui analise de causa raiz.");

            var html = await _razorRender.RenderViewToStringAsync("NonComplianceRegisterReport", nonComplianceRegister);

            return html;
        }
    }
}
