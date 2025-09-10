using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Queries.GetDestinationById
{
    public class GetDestinationByIdQuery : IRequest<Destination>
    {
    }
}
