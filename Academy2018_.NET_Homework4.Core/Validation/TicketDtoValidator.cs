using Academy2018_.NET_Homework4.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework4.Core.Validation
{
    public class TicketDtoValidator: AbstractValidator<TicketDto>
    {
        public TicketDtoValidator()
        {
            RuleFor(t => t.FlightNumber)
                .NotNull()
                .NotEmpty();
            RuleFor(t => t.Price)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
