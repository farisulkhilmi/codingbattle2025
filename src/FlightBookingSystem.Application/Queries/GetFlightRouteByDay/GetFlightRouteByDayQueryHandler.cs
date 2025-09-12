using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Queries.GetFlightRouteByDay
{
    public class GetFlightRouteByDayQueryHandler : IRequestHandler<GetFlightRouteByDayQuery, List<FlightRoute>>
    {
        private readonly IFlightRouteRepository _flightRouteRepository;
        public GetFlightRouteByDayQueryHandler(IFlightRouteRepository flightRouteRepository)
        {
            _flightRouteRepository = flightRouteRepository;
        }
        public async Task<List<FlightRoute>> Handle(GetFlightRouteByDayQuery request, CancellationToken cancellationToken)
        {
            var flightRoutes = await _flightRouteRepository.GetFlightRouteByDayAsync(request.Day);
            return flightRoutes;
        }
    }
}
