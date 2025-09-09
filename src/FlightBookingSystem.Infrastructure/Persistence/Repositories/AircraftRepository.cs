using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Infrastructure.Persistence.Repositories
{
    public class AircraftRepository : IAircraftRepository
    {
        private readonly ApplicationDbContext _db;

        public AircraftRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Aircraft aircraft, CancellationToken ct)
        {
            await _db.Aircrafts.AddAsync(aircraft, ct);
        }
       
    }
}
