using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Application.Abstractions
{
    public interface IDestinationRepository
    {
        Task AddAsync(Destination destination, CancellationToken ct);
        Task<Destination?> GetDestinationByName(string destinationName, CancellationToken cancellationToken);
    }
}
