using FluentValidation;

namespace _4lab.Administration.Application.DTOs.Validators
{
    public class DtoCreateAuthResponseValidator : AbstractValidator<DtoCreateAuthResponse>
    {
        public DtoCreateAuthResponseValidator()
        {
            RuleFor(x => x.User)
                .NotNull()
                .NotEmpty()
                .WithMessage("O usuario não pode ser nulo ou vazio.");
            RuleFor(x => x.Permission)
                .NotNull()
                .NotEmpty()
                .WithMessage("A permissão não pode ser nula ou vazia.");
            RuleFor(x => x.Token)
                .NotNull()
                .NotEmpty()
                .WithMessage("O token não pode ser nulo ou vazio.");
        }
    }
}
