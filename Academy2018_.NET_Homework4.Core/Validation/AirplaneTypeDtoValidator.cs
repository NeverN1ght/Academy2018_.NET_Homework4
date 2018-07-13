using Academy2018_.NET_Homework4.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework4.Core.Validation
{
    public class AirplaneTypeDtoValidator: AbstractValidator<AirplaneTypeDto>
    {
        public AirplaneTypeDtoValidator()
        {
            RuleFor(a => a.AirplaneModel)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
            RuleFor(a => a.CarryingCapacity)
                .NotNull()
                .GreaterThan(0);
            RuleFor(a => a.SeatsCount)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
