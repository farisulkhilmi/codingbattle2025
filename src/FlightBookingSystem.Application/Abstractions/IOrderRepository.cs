using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Application.Abstractions
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order, CancellationToken ct);
        Task UpdateOrderAsync(Order order, CancellationToken ct);
        Task<Order> GetOrderByBookingCode(string BookingCode, CancellationToken ct);
    }
}
