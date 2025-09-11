using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Infrastructure.Persistence.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly ApplicationDbContext _db;
        public DestinationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Destination destination, CancellationToken ct)
        {
            await _db.Destinations.AddAsync(destination, ct);
        }

        public async Task<Destination?> GetDestinationByName(string destinationName, CancellationToken cancellationToken)
        {
            return await _db.Destinations.FirstOrDefaultAsync(a => a.Name.ToLower() == destinationName, cancellationToken);
        }

        public async Task<IEnumerable<Destination>> GetAllDestinations(CancellationToken ct)
        {
            return await _db.Destinations.ToListAsync(ct);
        }
    }
}
