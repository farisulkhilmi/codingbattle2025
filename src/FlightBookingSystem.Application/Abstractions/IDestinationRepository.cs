using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Application.Abstractions
{
    public interface IDestinationRepository
    {
        Task AddAsync(Destination destination, CancellationToken ct);
    }
}
