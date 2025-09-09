using FlightBookingSystem.Domain.Domain;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateAircraft
{
    public class CreateAircraftCommand : IRequest<Aircraft>
    {
    }
}
