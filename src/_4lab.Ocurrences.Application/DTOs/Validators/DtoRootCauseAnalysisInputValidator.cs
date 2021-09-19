using FluentValidation;

namespace _4lab.Ocurrences.Application.DTOs.Validators
{
    public class DtoRootCauseAnalysisInputValidator : AbstractValidator<DtoRootCauseAnalysisInput>
    {
        public DtoRootCauseAnalysisInputValidator()
        {
            RuleFor(x => x.ActionPlain)
                .NotNull()
                .NotEmpty()
                .WithMessage("O plano de ação não pode ser nulo ou vazio");
            RuleFor(x => x.NonComplianceRegisterId)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id da não conformidade não pode ser vazio ou nulo.");
        }
    }
}
