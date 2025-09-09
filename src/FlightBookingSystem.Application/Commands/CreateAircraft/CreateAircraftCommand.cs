using FlightBookingSystem.Domain.Dto;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateAircraft
{
    public class CreateAircraftCommand : AircraftRequestDto, IRequest<Guid>
    {
    }
}
