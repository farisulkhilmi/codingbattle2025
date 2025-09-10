using FluentValidation;

namespace FlightBookingSystem.Application.Commands.CreateDestination
{
    public class CreateDestinatorValidator : AbstractValidator<CreateDestinationCommand>
    {
        public CreateDestinatorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.DestinationCode).NotEmpty().MaximumLength(5);
        }
    }
}
