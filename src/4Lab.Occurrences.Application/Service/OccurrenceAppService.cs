using _4lab.Infrastructure.Storage;
using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Infrastructure.Charts;
using _4Lab.Infrastructure.Render.Html;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace _4lab.Occurrences.Application.Service
{
    public class OccurrenceAppService : IOccurrenceAppService
    {
        private readonly IMapper _mapper;
        private readonly IActionPlainRepository _actionPlainRepository;
        private readonly IActionPlainQuestionRepository _actionPlainQuestionRepository;
        private readonly IOccurrenceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IOccurrenceRepository _occurrenceRepository;
        private readonly IRootCauseAnalysisRepository _analyzeRootCauseRepository;
        private readonly IRazorRender _razorRender;

        public OccurrenceAppService(IActionPlainRepository actionPlainRepository
                                   , IActionPlainQuestionRepository actionPlainQuestionRepository
                                   , IMapper mapper
                                   , IOccurrenceRegisterRepository nonComplianceRegisterRepository
                                   , IOccurrenceRepository occurrenceRepository
                                   , IRootCauseAnalysisRepository analyzeRootCauseRepository
                                   , IRazorRender razorRender)
        {
            _actionPlainRepository = actionPlainRepository;
            _actionPlainQuestionRepository = actionPlainQuestionRepository;
            _mapper = mapper;
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _occurrenceRepository = occurrenceRepository;
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

        public async Task<bool> CreateOccurrenceRegister(DtoOccurrenceRegister occurrenceRegister)
        {
            if (occurrenceRegister.RegisterDate == DateTime.MinValue)
                throw new Exception("A data precisa ser informada.");

            if (occurrenceRegister.RegisterHour == null)
                throw new Exception("O horário que ocorreu a não conformidade precisa ser informada.");

            if (string.IsNullOrEmpty(occurrenceRegister.ImmediateAction))
                throw new Exception("A ação imediata não pode ser vazia.");

            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                var notExistingOccurrence = await CreateNewOccurrences(occurrenceRegister.UserName, occurrenceRegister.Occurrences.Where(x => !x.Id.HasValue));
                var existingOccurrence = await CheckExistingOccurrence(occurrenceRegister.Occurrences.Where(x => x.Id.HasValue));

                if (!existingOccurrence.Any())
                    throw new Exception("Não existe não conformidades.");

                var allOccurrences = existingOccurrence.Union(notExistingOccurrence);

                var entity = await _nonComplianceRegisterRepository
                                              .Insert(new OccurrenceRegister
                                              {
                                                  UserId = occurrenceRegister.UserId,
                                                  ImmediateAction = occurrenceRegister.ImmediateAction,
                                                  MoreInformation = occurrenceRegister.MoreInformation,
                                                  PeopleInvolved = occurrenceRegister.PeopleInvolved,
                                                  RegisterDate = occurrenceRegister.RegisterDate,
                                                  RegisterHour = occurrenceRegister.RegisterHour,
                                                  SetorId = occurrenceRegister.Setor,
                                                  CreatedAt = DateTime.Now,
                                                  Occurrences = allOccurrences.ToList(),
                                                  CreatedBy = occurrenceRegister.UserName,
                                                  OccurrencePendency = OccurrencePendency.RootCauseAnalysisAndActionPlan,
                                                  OccurrenceClassificationId = occurrenceRegister.OccurrenceClassification
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
        private async Task<List<Occurrence>> CreateNewOccurrences(string creationUserName, IEnumerable<DtoOccurrence> occurrences)
        {
            if (!occurrences.Any())
                return new List<Occurrence>();

            var newOccurrences = new List<Occurrence>();

            foreach (var oc in occurrences)
            {
                var occurrence = await _occurrenceRepository.Insert(new Occurrence
                {
                    Active = false,
                    Description = oc.Description,
                    OccurrenceTypeId = oc.OccurrenceTypeId,
                    CreatedAt = DateTime.Now,
                    CreatedBy = creationUserName
                });

                await _occurrenceRepository.SaveChanges();

                newOccurrences.Add(occurrence);
            }


            return newOccurrences;
        }

        private async Task<List<Occurrence>> CheckExistingOccurrence(IEnumerable<DtoOccurrence> occurrences)
        {
            var occurrencesResult = new List<Occurrence>();

            foreach (var nc in occurrences)
            {
                var hasOccurrence = await _occurrenceRepository.GetById(nc.Id.Value);

                if (hasOccurrence == null)
                    throw new Exception($"Não foi encontrado a não conformidade com descrição: {nc.Description}.");

                occurrencesResult.Add(hasOccurrence);
            }

            return occurrencesResult;
        }

        public async Task<RootCauseAnalysis> CreateRootCauseAnalysis(DtoRootCauseAnalysisInput analyzeRootCause)
        {
            var nonComplianceRegister = await _nonComplianceRegisterRepository.GetByIdWithInclude(analyzeRootCause.OccurrenceRegisterId);

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
                    OccurrenceRegisterId = analyzeRootCause.OccurrenceRegisterId,
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

        public async Task<DtoOccurrenceRegisterResponse> GetOccurrenceRegisterById(Guid id)
        {
            var occurrenceRegister = await _nonComplianceRegisterRepository.GetByIdWithInclude(id);
            return _mapper.Map<DtoOccurrenceRegisterResponse>(occurrenceRegister);
        }

        public async Task<byte[]> CreatePieChartWithOccurrenceRegister(SetorType setor, int month)
        {
            var occurrenceGroup = await _nonComplianceRegisterRepository.GetGroupBySetor(setor, month);

            var chartData = occurrenceGroup.ToDictionary(k => k.Occurrence,
                                                        v => (double)(v.Quantity));

            var chart = ChartGenerator.GeneratePieChart(chartData);

            return chart;
        }

        public async Task<string> CreateOccurrenceRegisterReport(Guid occurrenceRegisterId)
        {
            var occurrenceRegister = await _nonComplianceRegisterRepository.GetByIdForReport(occurrenceRegisterId);

            if (occurrenceRegister == null)
                throw new Exception("Registro de não conformidade não encontrado.");

            if (!occurrenceRegister.HasRootCauseAnalysis())
                throw new Exception("Resgistro ainda não possui analise de causa raiz.");

            var html = await _razorRender.RenderViewToStringAsync("OccurrenceRegisterReport", occurrenceRegister);

            return html;
        }
    }
}
