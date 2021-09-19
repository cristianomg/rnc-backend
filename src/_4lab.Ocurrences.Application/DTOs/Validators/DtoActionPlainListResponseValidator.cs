using FluentValidation;

namespace _4lab.Ocurrences.Application.DTOs.Validators
{
    public class DtoActionPlainListResponseValidator : AbstractValidator<DtoActionPlainListResponse>
    {
        public DtoActionPlainListResponseValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("O Id não pode ser nulo ou vazio");
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(50)
                .MaximumLength(150)
                .WithMessage("O nome não pode ser vazio ou nulo.");
        }
    }
}
