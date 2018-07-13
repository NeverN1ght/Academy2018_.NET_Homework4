using Academy2018_.NET_Homework4.Shared.DTOs;
using FluentValidation;

namespace Academy2018_.NET_Homework4.Core.Validation
{
    public class CrewDtoValidator: AbstractValidator<CrewDto>
    {
        public CrewDtoValidator()
        {
            RuleFor(c => c.Pilot)
                .NotNull();
            RuleForEach(c => c.Stewardesses)
                .NotNull();
        }
    }
}
