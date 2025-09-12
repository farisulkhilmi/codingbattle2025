using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Order> GetOrderByBookingCode(string bookingCode, CancellationToken ct)
        {
            return await _db.Orders.FirstOrDefaultAsync(or => or.BookingCode.ToLower() == bookingCode.ToLower());
        }

        public async Task UpdateOrderAsync(Order order, CancellationToken ct)
        {
            var value = await _db.Orders.FirstOrDefaultAsync(or => or.BookingCode.ToLower() == order.BookingCode.ToLower());

            if (value != null)
            {
                value = order;
            }

            _db.Orders.Update(value);
        }
    }
}
