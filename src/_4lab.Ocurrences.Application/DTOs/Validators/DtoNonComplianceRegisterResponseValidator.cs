using FluentValidation;

namespace _4lab.Ocurrences.Application.DTOs.Validators
{
    public class DtoNonComplianceRegisterResponseValidator : AbstractValidator<DtoNonComplianceRegisterResponse>
    {
        public DtoNonComplianceRegisterResponseValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id não pode ser nulo ou vazio.");
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Nome de usuario não pode ser nulo ou vazio.");
            RuleFor(x => x.Date)
                .NotNull()
                .NotEmpty()
                .WithMessage("A data não pode ser nula ou vazia.");
            RuleFor(x => x.Hour)
                .NotNull()
                .NotEmpty()
                .WithMessage("A hora não pode ser nula ou vazia.");
            RuleFor(x => x.Setor)
                .NotNull()
                .NotEmpty()
                .WithMessage("o setor não pode ser nulo ou vazio.");
            RuleFor(x => x.PeopleInvolved)
                .NotNull()
                .NotEmpty()
                .WithMessage("As pessoas involvidas não pode ser nulas ou vazias.");
            RuleFor(x => x.HasRootCauseAnalysis)
                .NotNull()
                .NotEmpty()
                .WithMessage("A causa de analize não pode ser nula ou vazia.");
        }
    }
}
