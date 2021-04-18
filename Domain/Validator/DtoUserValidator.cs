
using Domain.Dtos.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validator
{
    public class DtoUserValidator : AbstractValidator<DtoCreateUserInput>
    {
        public DtoUserValidator()
        {
            RuleFor(x => x.CompleteName)
                .NotNull()
                .Matches("^[a-zA-Z ]*$")
                .NotEmpty()
                .MaximumLength(20)
                .MinimumLength(150)
                .WithMessage("O Nome não pode ser vazio ou nulo.");
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .Matches("^[a-zA-Z ]*$")
                .WithMessage("O email não pode ser vazio ou nulo.");
            RuleFor(x => x.Crbm)
                .NotNull()
                .NotEmpty()
                .WithMessage("O CRBM não pode ser vazio ou nulo.");
            RuleFor(x => x.Enrollment)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("A matricula não pode ser vazio ou nulo.");
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia ou nula.");
            RuleFor(x => x.ConfirmPassword)
                .NotNull()
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("A confirmação de senha não pode ser vazia ou nula.");
            RuleFor(x => x.Setor)
                .NotNull()
                .NotEmpty()
                .WithMessage("O setor não pode ser vazio ou nulo.");
            RuleFor(x => x.UserPermission)
                .NotEmpty()
                .WithMessage("A permissão do usuario não pode ser vazia.");
        }  
    }
}
