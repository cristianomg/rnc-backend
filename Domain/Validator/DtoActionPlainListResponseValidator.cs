using Domain.Dtos.Responses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validator
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
