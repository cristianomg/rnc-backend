using FluentValidation;

namespace _4lab.Ocurrences.Application.DTOs.Validators
{
    public class DtoNonComplianceValidator : AbstractValidator<DtoNonCompliance>
    {
        public DtoNonComplianceValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id não pode ser nulo ou vazio.");
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("A descrição não pode ser nula ou vazia.");
            RuleFor(x => x.NameNonCompliance)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome da não confomidade não pode ser nula ou vazia.");
            RuleFor(x => x.TypeNonComplianceId)
                .NotNull()
                .NotEmpty()
                .WithMessage("O tipo da não conformidade não pode ser nulo ou vazi.");


        }
    }
}
