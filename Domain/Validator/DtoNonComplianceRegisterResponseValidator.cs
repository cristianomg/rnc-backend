using Domain.Dtos.Responses;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validator
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
            RuleFor(x => x.NonCompliance)
                .NotNull()
                .NotEmpty()
                .WithMessage("A não conformidade não pode ser nula ou vazia.");
            RuleFor(x => x.NonComplianceType)
                .NotNull()
                .NotEmpty()
                .WithMessage("O tipo de não conformidade não pode ser nulo ou vazio.");
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
