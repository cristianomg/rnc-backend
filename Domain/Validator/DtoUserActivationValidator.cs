using Domain.Dtos.Helps;
using FluentValidation;

namespace Domain.Validator
{
    public class DtoUserActivationValidator : AbstractValidator<DtoUserActive>
    {
        public DtoUserActivationValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Id não pode ser vazio ou nulo."); ;
            RuleFor(x => x.CompleteName)
               .NotNull()
               .Matches("^[a-zA-Z ]*$")
               .NotEmpty()
               .MaximumLength(20)
               .MinimumLength(150)
               .WithMessage("O Nome não pode ser vazio ou nulo.");
            RuleFor(x => x.Email)
                .EmailAddress();
            RuleFor(x => x.Enrollment)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("A matricula não pode ser vazio ou nulo.");
            RuleFor(x => x.Setor)
                .NotNull()
                .NotEmpty()
                .WithMessage("O setor não pode ser vazio ou nulo.");
            RuleFor(x => x.Active)
                .NotEmpty()
                .NotNull()
                .WithMessage("A permissão do usuario não pode ser vazia.");
        }
    }
}
