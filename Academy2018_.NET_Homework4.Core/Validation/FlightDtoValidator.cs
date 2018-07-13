using Academy2018_.NET_Homework4.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework4.Core.Validation
{
    public class FlightDtoValidator: AbstractValidator<FlightDto>
    {
        public FlightDtoValidator()
        {
            RuleFor(f => f.Number)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
            RuleForEach(f => f.Tickets)
                .NotNull()
                .NotEmpty();
            RuleFor(f => f.ArrivalTime)
                .NotNull()
                .NotEmpty();
            RuleFor(f => f.DeparturePoint)
                .NotNull()
                .NotEmpty();
            RuleFor(f => f.DestinationPoint)
                .NotNull()
                .NotEmpty();
        }
    }
}
