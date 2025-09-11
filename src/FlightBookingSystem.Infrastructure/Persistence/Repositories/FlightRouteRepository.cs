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

        public async Task<IEnumerable<FlightRoute>> GetAllFlightRoutesAsync(CancellationToken ct)
        {
            return await _db.FlightRoutes
                .Include(fr => fr.Origin)
                .Include(fr => fr.Destination)
                .Include(fr => fr.Aircraft)
                .ToListAsync(ct);
        }
    }
}
