using Academy2018_.NET_Homework4.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework4.Core.Validation
{
    public class DepartureDtoValidator: AbstractValidator<DepartureDto>
    {
        public DepartureDtoValidator()
        {
            RuleFor(d => d.Airplane)
                .NotNull();
            RuleFor(d => d.Crew)
                .NotNull();
            RuleFor(d => d.DepartureTime)
                .NotNull();
            RuleFor(d => d.FlightNumber)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
