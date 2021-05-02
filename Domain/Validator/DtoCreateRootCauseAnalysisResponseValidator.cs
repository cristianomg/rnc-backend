using Domain.Dtos.Responses;
using FluentValidation;

namespace Domain.Validator
{
    public class DtoCreateRootCauseAnalysisResponseValidator : AbstractValidator<DtoCreateRootCauseAnalysisResponse>
    {
        public DtoCreateRootCauseAnalysisResponseValidator()
        {
            RuleFor(x => x.NonComplianceRegisterId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id da não conformidade não pode ser nulo ou vazio");
            RuleFor(x => x.Analyze)
                .NotNull()
                .NotEmpty()
                .WithMessage("O analizador não pode ser nulo ou vazio.");
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id de usuario não pode ser nulo ou vazio");
            RuleFor(x => x.ActionPlainId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id do plano de ação não pode ser nulo ou vazio");
            RuleFor(x => x.ActionPlainResponses)
                .NotNull()
                .NotEmpty()
                .WithMessage("A resposta do plano de ação não pode ser nulo ou vazio");
        }
    }

}
