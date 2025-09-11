using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Order order, CancellationToken ct)
        {
            await _db.Orders.AddAsync(order, ct);
        }
    }
}
