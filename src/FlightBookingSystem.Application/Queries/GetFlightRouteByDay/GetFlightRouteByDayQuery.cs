using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Queries.GetFlightRouteByDay
{
    public class GetFlightRouteByDayQuery : IRequest<List<FlightRoute>>
    {
        public int Day { get; set; }
    }
}
