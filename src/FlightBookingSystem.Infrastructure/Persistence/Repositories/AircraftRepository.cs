using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Aircraft?> GetAircraftByNameAsync(string name, CancellationToken ct)
        {
            return await _db.Aircrafts.FirstOrDefaultAsync(a => a.Name.ToLower() == name, ct);
        }
    }
}
