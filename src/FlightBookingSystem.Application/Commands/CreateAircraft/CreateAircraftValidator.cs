using FluentValidation;

namespace FlightBookingSystem.Application.Commands.CreateAircraft
{
    public class CreateAircraftValidator : AbstractValidator<CreateAircraftCommand>
    {
        public CreateAircraftValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.SeatCapacity).GreaterThan(0).LessThanOrEqualTo(10);
        }
    }
}
