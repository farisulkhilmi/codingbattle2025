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

        public async Task<IEnumerable<Destination>> FindByName(string destinationName, CancellationToken cancellationToken)
        {
            var destination = await _db.Destinations
               .Where(d => d.Name == destinationName).ToListAsync();

            return destination;
        }
    }
}
