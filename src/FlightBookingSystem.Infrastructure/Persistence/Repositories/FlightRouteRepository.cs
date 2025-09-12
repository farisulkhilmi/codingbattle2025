using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Infrastructure.Persistence.Repositories
{
    public class FlightRouteRepository : IFlightRouteRepository
    {
        private readonly ApplicationDbContext _db;

        public FlightRouteRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(FlightRoute flightRoute, CancellationToken ct)
        {
            await _db.FlightRoutes.AddAsync(flightRoute, ct);
        }

        public async Task<FlightRoute?> GetFlightRouteByOriginAndDestAsync(Guid originId, Guid destId, int day, CancellationToken ct)
        {
            return await _db.FlightRoutes.FirstOrDefaultAsync(x => x.OriginId == originId && x.DestinationId == destId && x.ScheduledDay == day, ct);
        }

        public async Task<FlightRoute?> GetFlightRouteByIdAsync(Guid id, CancellationToken ct)
        {
            return await _db.FlightRoutes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<FlightRoute>> GetAllFlightRoutesAsync(CancellationToken ct)
        {
            return await _db.FlightRoutes
                .Include(fr => fr.Origin)
                .Include(fr => fr.Destination)
                .Include(fr => fr.Aircraft)
                .ToListAsync(ct);
        }

        public async Task<List<FlightRoute>> GetFlightRouteByDayAsync(int day)
        {
            return await _db.FlightRoutes
                .Include(fr => fr.Origin)
                .Include(fr => fr.Destination)
                .Include(fr => fr.Aircraft)
                .Where(fr => fr.ScheduledDay == day)
                .ToListAsync();
        }

        public async Task UpdateFlightRoute(FlightRoute flightRoute, CancellationToken ct)
        {
            var existingFlightRoute = await _db.FlightRoutes.FirstOrDefaultAsync(fr => fr.Id == flightRoute.Id, ct);
            if (existingFlightRoute != null)
            {
                existingFlightRoute = flightRoute;
            }
            _db.FlightRoutes.Update(flightRoute);
        }
    }
}
