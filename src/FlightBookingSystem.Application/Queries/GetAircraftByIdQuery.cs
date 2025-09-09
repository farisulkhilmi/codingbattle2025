using FlightBookingSystem.Domain.Domain;
using MediatR;

namespace FlightBookingSystem.Application.Queries
{
    public class GetAircraftByIdQuery : IRequest<Aircraft>
    {
    }
}
