using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using Service.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Service.Services
{
    public class CreateRootCauseAnalysisService : AbstractService, ICreateRootCauseAnalysisService
    {
        private readonly IRootCauseAnalysisRepository _analyzeRootCauseRepository;
        private readonly INonComplianceRegisterRepository _nonComplianceRegisterRepository;
        private readonly IActionPlainRepository _actionPlainRepository;

        public CreateRootCauseAnalysisService(IRootCauseAnalysisRepository analyzeRootCauseRepository,
                                      INonComplianceRegisterRepository nonComplianceRegisterRepository,
                                      IActionPlainRepository actionPlainRepository)
        {
            _analyzeRootCauseRepository = analyzeRootCauseRepository;
            _nonComplianceRegisterRepository = nonComplianceRegisterRepository;
            _actionPlainRepository = actionPlainRepository;
        }

        public async Task<ResponseService<RootCauseAnalysis>> Execute(DtoRootCauseAnalysisInput analyzeRootCause)
        {
            var nonComplianceRegister = await
                _nonComplianceRegisterRepository.GetByIdWithInclude(analyzeRootCause.NonComplianceRegisterId);

            if (nonComplianceRegister == null)
                return GenerateErroServiceResponse<RootCauseAnalysis>("Registro de não conformidade não encontrado.");

            if (nonComplianceRegister.RootCauseAnalysis != null)
                return GenerateErroServiceResponse<RootCauseAnalysis>
                       ("O registro de não conformidade já foi analisado.");
            using (var scoped = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var actionPlain = await _actionPlainRepository.GetByIdWithIncludes(analyzeRootCause.ActionPlain.Id.Value);

                    if (actionPlain == null)
                        return GenerateErroServiceResponse<RootCauseAnalysis>("O plano de ação não foi encontrado.");

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
                    return GenerateSuccessServiceResponse(newAnalyzeRootCause);
                }
                catch (ServiceException ex)
                {
                    scoped.Dispose();
                    return GenerateErroServiceResponse<RootCauseAnalysis>(ex.Message);
                }
                catch (Exception)
                {
                    scoped.Dispose();
                    return GenerateErroServiceResponse<RootCauseAnalysis>("Erro ao inserir analise.");
                }
            }

        }
    }
}
