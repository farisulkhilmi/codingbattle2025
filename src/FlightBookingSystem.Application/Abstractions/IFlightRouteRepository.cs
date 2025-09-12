using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Application.Abstractions
{
    public interface IFlightRouteRepository
    {
        Task AddAsync(FlightRoute flightRoute, CancellationToken ct);
        Task<FlightRoute?> GetFlightRouteByOriginAndDestAsync(Guid originId, Guid destId, int day, CancellationToken ct);
        Task<IEnumerable<FlightRoute>> GetAllFlightRoutesAsync(CancellationToken ct);
        Task<List<FlightRoute>> GetFlightRouteByDayAsync(int day);
    }
}
