using _4lab.Infrastructure.Storage;
using _4lab.Occurrences.Application.DTOs;
using _4lab.Occurrences.Domain.Interfaces;
using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Infrastructure.Charts;
using _4Lab.Infrastructure.Render.Html;
using _4Lab.Occurrences.Application.DTOs;
using _4Lab.Occurrences.Domain.Interfaces;
using _4Lab.Occurrences.Domain.Models;
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
        private readonly IOccurrenceRegisterRepository _occurrenceRegisterRepository;
        private readonly IOccurrenceRepository _occurrenceRepository;
        private readonly IRootCauseAnalysisRepository _analyzeRootCauseRepository;
        private readonly IRazorRender _razorRender;
        private readonly IVerificationOfEffectivenessRepository _verificationOfEffectivenessRepository;

        public OccurrenceAppService(IActionPlainRepository actionPlainRepository
                                   , IActionPlainQuestionRepository actionPlainQuestionRepository
                                   , IMapper mapper
                                   , IOccurrenceRegisterRepository occurrenceRegisterRepository
                                   , IOccurrenceRepository occurrenceRepository
                                   , IRootCauseAnalysisRepository analyzeRootCauseRepository
                                   , IRazorRender razorRender
                                   , IVerificationOfEffectivenessRepository verificationOfEffectivenessRepository)
        {
            _actionPlainRepository = actionPlainRepository;
            _actionPlainQuestionRepository = actionPlainQuestionRepository;
            _mapper = mapper;
            _occurrenceRegisterRepository = occurrenceRegisterRepository;
            _occurrenceRepository = occurrenceRepository;
            _analyzeRootCauseRepository = analyzeRootCauseRepository;
            _razorRender = razorRender;
            _verificationOfEffectivenessRepository = verificationOfEffectivenessRepository;
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
                var notExistingOccurrence = await CreateNewOccurrences(occurrenceRegister.UserName, occurrenceRegister.Occurrences.Where(x => !x.IsExisting));
                var existingOccurrence = await CheckExistingOccurrence(occurrenceRegister.Occurrences.Where(x => x.IsExisting));

                var allOccurrences = existingOccurrence.Union(notExistingOccurrence);

                if (!allOccurrences.Any())
                    throw new Exception("Não existe ocorrencias.");

                var entity = await _occurrenceRegisterRepository
                                              .Insert(new OccurrenceRegister
                                              {
                                                  Id = occurrenceRegister.Id,
                                                  UserId = occurrenceRegister.UserId,
                                                  ImmediateAction = occurrenceRegister.ImmediateAction,
                                                  MoreInformation = occurrenceRegister.MoreInformation,
                                                  PeopleInvolved = occurrenceRegister.PeopleInvolved,
                                                  RegisterDate = occurrenceRegister.RegisterDate,
                                                  RegisterHour = occurrenceRegister.RegisterHour,
                                                  SetorId = occurrenceRegister.Setor,
                                                  CreatedAt = DateTime.Now,
                                                  OccurrenceTypeId = occurrenceRegister.OccurrenceTypeId,
                                                  Occurrences = allOccurrences.ToList(),
                                                  CreatedBy = occurrenceRegister.UserName,
                                                  OccurrencePendency = OccurrencePendency.RootCauseAnalysisAndActionPlan,
                                                  OccurrenceClassificationId = occurrenceRegister.OccurrenceClassification,
                                              });

                await _occurrenceRegisterRepository.SaveChanges();

                scope.Complete();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
                    Id = oc.Id.Value,
                    Active = false,
                    Description = oc.Description,
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

        public async Task<bool> CreateRootCauseAnalysis(DtoRootCauseAnalysisInput analyzeRootCause)
        {
            var occurrenceRegister = await _occurrenceRegisterRepository.GetByIdWithInclude(analyzeRootCause.OccurrenceRegisterId);

            if (occurrenceRegister == null)
                throw new Exception("O Registro de não conformidade não encontrado.");

            if (occurrenceRegister.OccurrencePendency != OccurrencePendency.RootCauseAnalysisAndActionPlan)
                throw new Exception("O Registro não está pendente de análise de causa raiz");

            if (occurrenceRegister.RootCauseAnalysis != null)
                throw new Exception("O registro de não conformidade já foi analisado.");

            var actionPlain = await _actionPlainRepository.GetByIdWithIncludes(analyzeRootCause.ActionPlain.Id.Value);
            
            if (actionPlain == null)
                throw new Exception("O plano de ação não foi encontrado.");

            using var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            try
            {
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

                var analysis = await _analyzeRootCauseRepository.Insert(new RootCauseAnalysis
                {
                    OccurrenceRegisterId = analyzeRootCause.OccurrenceRegisterId,
                    UserId = analyzeRootCause.UserId,
                    CreatedBy = analyzeRootCause.UserName,
                    FiveWhats = fivewhats,
                    ActionPlainId = actionPlain.Id,
                    ActionPlain = actionPlain,
                    ActionPlainResponses = responses
                });

                occurrenceRegister.OccurrencePendency = OccurrencePendency.RiskRating;
                occurrenceRegister.RootCauseAnalysis = analysis;
                occurrenceRegister.CreatedRootCauseAnalysis = DateTime.Now;

                await _occurrenceRegisterRepository.SaveChanges();

                scoped.Complete();
                return true;
            }
            catch (Exception ex)
            {
                scoped.Dispose();
                throw new Exception("Erro ao inserir analise.");
            }
        }

        public async Task<DtoOccurrenceRegisterResponse> GetOccurrenceRegisterById(Guid id)
        {
            var occurrenceRegister = await _occurrenceRegisterRepository.GetByIdWithInclude(id);
            return _mapper.Map<DtoOccurrenceRegisterResponse>(occurrenceRegister);
        }

        public async Task<byte[]> CreatePieChartWithOccurrenceRegister(SetorType setor, int month)
        {
            var occurrenceGroup = await _occurrenceRegisterRepository.GetGroupBySetor(setor, month);

            var chartData = occurrenceGroup.ToDictionary(k => k.Occurrence,
                                                        v => (double)(v.Quantity));

            var chart = ChartGenerator.GeneratePieChart(chartData);

            return chart;
        }

        public async Task<string> CreateOccurrenceRegisterReport(Guid occurrenceRegisterId)
        {
            var occurrenceRegister = await _occurrenceRegisterRepository.GetByIdForReport(occurrenceRegisterId);

            if (occurrenceRegister == null)
                throw new Exception("Registro de não conformidade não encontrado.");

            if (!occurrenceRegister.HasAllAnalysis())
                throw new Exception("Registro ainda está em análise.");

            var html = await _razorRender.RenderViewToStringAsync("OccurrenceRegisterReport", occurrenceRegister);

            return html;
        }

        public async Task<bool> CreateRiskAnalysis(DtoRiskAnalysisInput riskAnalysis)
        {
            var occurrenceRegisterRegister = await _occurrenceRegisterRepository.GetByIdWithInclude(riskAnalysis.OccurrenceRegisterId);

            if (occurrenceRegisterRegister == null)
                throw new Exception("O Registro de não conformidade não encontrado.");

            if (occurrenceRegisterRegister.OccurrencePendency != OccurrencePendency.RiskRating)
                throw new Exception("O Registro não está pendente de análise de risco");

            if (occurrenceRegisterRegister.OccurrenceRiskId != null)
                throw new Exception("O registro de não conformidade já foi analisado.");

            using var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                occurrenceRegisterRegister.OccurrencePendency = OccurrencePendency.VerificationOfEffectiveness;
                occurrenceRegisterRegister.OccurrenceRiskId = riskAnalysis.OccurenceRisk;
                occurrenceRegisterRegister.CreatedOcurrenceRisk = DateTime.Now;

                await _occurrenceRegisterRepository.Update(occurrenceRegisterRegister);

                await _analyzeRootCauseRepository.SaveChanges();

                scoped.Complete();
                return true;
            }
            catch
            {
                scoped.Dispose();
                throw new Exception("Erro ao inserir analise.");
            }
        }
        public async Task<bool> VerifyEffectiveness(DtoVerificationOfEffectivenessInput dto)
        {

            var occurrenceRegister = await _occurrenceRegisterRepository.GetById(dto.OccurrenceRegisterId);

            if (occurrenceRegister is null)
                throw new Exception("Registro de ocorrencia não encontrado.");

            if (occurrenceRegister.OccurrencePendency != OccurrencePendency.VerificationOfEffectiveness)
                throw new Exception("Registro de ocorrencia não está disponivel para verificação de eficacia.");

            if (occurrenceRegister.CanVerifyEffectiveness)
                throw new Exception("O periodo para verificação de eficacia ainda não está ativo.");

            using var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                occurrenceRegister.OccurrencePendency = null;
                occurrenceRegister.CreatedVerificatoinOfEffectiveness = DateTime.Now;

                await _occurrenceRegisterRepository.Update(occurrenceRegister);

                await _verificationOfEffectivenessRepository.Insert(
                    new VerificationOfEffectiveness(dto.OccurrenceRegisterId, dto.Description, dto.UserName));

                await _verificationOfEffectivenessRepository.SaveChanges();

                scoped.Complete();
                return true;
            }
            catch
            {
                scoped.Dispose();
                throw new Exception("Erro ao inserir analise.");
            }

        }

        public async void DeleteOccurrenceRegister(Guid id)
        {
            var obj = await _occurrenceRegisterRepository.GetById(id);

            if (obj.IsDeleted == null)
                throw new Exception("O Registro de Ocorrencia não foi encontrado");

            if (obj.IsDeleted == true)
                throw new Exception("O Registro de Ocorrencia já foi deletado");

            if (id == null)
                throw new Exception("O Id está incorreto ou não exite resgistro de Ocorrencia já foi deletado");

            await _occurrenceRegisterRepository.Delete(obj);

            await _occurrenceRegisterRepository.SaveChanges();
        }
    }
}
