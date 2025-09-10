using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Application.Abstractions
{
    public interface IDestinationRepository
    {
        Task AddAsync(Destination destination, CancellationToken ct);
        Task<IEnumerable<Destination>> FindByName(string destinationName, CancellationToken cancellationToken);
    }
}
