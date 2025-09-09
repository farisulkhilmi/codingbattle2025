using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Queries.GetAircraftById
{
    public class GetAircraftByIdQuery : IRequest<Aircraft>
    {
    }
}
