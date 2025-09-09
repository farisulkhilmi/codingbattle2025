using FlightBookingSystem.Domain.Domain;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateAircraft
{
    public class CreateAircraftCommandHandler : IRequestHandler<CreateAircraftCommand, Aircraft>
    {
        public Task<Aircraft> Handle(CreateAircraftCommand request, CancellationToken cancellationToken)
        {
            var aircraft = new Aircraft
            {
                Name = "Boeing 737",
                TailNumber = "N737EX",
                SeatCapacity = 160,
                CreatedBy = "System",
                CreatedAt = DateTime.UtcNow
            };
            // In a real application, you would save the aircraft to the database here.
            return Task.FromResult(aircraft);
        }
    }
}
