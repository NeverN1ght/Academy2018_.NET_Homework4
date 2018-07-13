using System;
using Academy2018_.NET_Homework4.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework4.Core.Validation
{
    public class PilotDtoValidator: AbstractValidator<PilotDto>
    {
        public PilotDtoValidator()
        {
            RuleFor(p => p.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(15);
            RuleFor(p => p.LastName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);
            RuleFor(p => p.Birthdate)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now);
            RuleFor(p => p.Experience)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
