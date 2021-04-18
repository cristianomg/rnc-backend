using Domain.Dtos.Responses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validator
{
    public class DtoActionPlainDetailResponseValidator : AbstractValidator<DtoActionPlainDetailResponse>
    {
        public DtoActionPlainDetailResponseValidator()
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
            RuleFor(x => x.Questions)
                .NotNull()
                .NotEmpty()
                .WithMessage("As questôes não pode ser vazia");
        }
    }
}
