using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using Service.Services.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Service.Services
{
    public class CreateActionPlainService : AbstractService, ICreateActionPlainService
    {
        private readonly IActionPlainRepository _actionPlainRepository;
        private readonly IActionPlainQuestionRepository _actionPlainQuestionRepository;
        public CreateActionPlainService(IActionPlainRepository actionPlainRepository,
                                        IActionPlainQuestionRepository actionPlainQuestionRepository)
        {
            _actionPlainRepository = actionPlainRepository;
            _actionPlainQuestionRepository = actionPlainQuestionRepository;
        }  

        public async Task<ResponseService> Execute(DtoCreateActionPlainInput dto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var hasActionPlainWithName = await _actionPlainRepository.GetAll(x => x.Name.ToLower() == dto.Name.ToLower());
                    if (hasActionPlainWithName.FirstOrDefault() != null)
                        throw new ServiceException("Já existe um plano de ação com esse nome.");

                    var questions = dto.Questions
                          .Select(x => new ActionPlainQuestion
                          {
                              Value = x.Value,
                              CreatedAt = DateTime.Now,
                              Active = true,
                          }).ToList();

                    var actionPlain = new ActionPlain
                    {
                        Name = dto.Name,
                        Active = true,
                        CreatedAt = DateTime.Now,
                        Questions = questions
                    };
                    actionPlain = await _actionPlainRepository.Insert(actionPlain);

                    await _actionPlainRepository.SaveChanges();

                    actionPlain.Questions = await _actionPlainQuestionRepository.GetAll(x => x.ActionPlainId == actionPlain.Id);

                    await _actionPlainRepository.SaveChanges();

                    scope.Complete();

                    return GenerateSuccessServiceResponse();
                }
                catch (ServiceException ex)
                {
                    scope.Dispose();
                    return GenerateErroServiceResponse(ex.Message);
                }
                catch(Exception)
                {
                    scope.Dispose();
                    return GenerateErroServiceResponse("Erro ao criar plano de ação.");
                }
            }
        }
    }
}
