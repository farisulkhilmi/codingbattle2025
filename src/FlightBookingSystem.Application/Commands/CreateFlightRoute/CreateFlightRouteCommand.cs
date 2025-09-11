using FlightBookingSystem.Domain.Dto;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateFlightRoute
{
    public class CreateFlightRouteCommand : FlightRouteDto, IRequest<Guid>
    {
    }
}
