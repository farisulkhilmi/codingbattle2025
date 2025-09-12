using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Commands.UpdateFlightRoute
{
    public class UpdateFligthRouteCommand : FlightRoute, IRequest<Guid>
    {
    }
}
