using Domain.Dtos.Responses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validator
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
