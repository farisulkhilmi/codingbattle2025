namespace FlightBookingSystem.Application.Abstractions
{
    public interface IOrderRepository
    {
        Task AddAsync(Domain.Entities.Order order, CancellationToken ct);
    }
}
