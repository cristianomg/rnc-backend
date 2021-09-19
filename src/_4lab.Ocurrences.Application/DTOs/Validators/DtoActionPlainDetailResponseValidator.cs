﻿using FluentValidation;

namespace _4lab.Ocurrences.Application.DTOs.Validators
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