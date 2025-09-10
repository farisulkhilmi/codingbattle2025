using FlightBookingSystem.Domain.Dto;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateDestination
{
    public class CreateDestinationCommand : DestinationRequestDto, IRequest<Guid>
    {
    }
}
