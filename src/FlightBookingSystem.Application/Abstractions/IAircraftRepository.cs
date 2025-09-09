using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Application.Abstractions
{
    public interface IAircraftRepository
    {
        Task AddAsync(Aircraft aircraft, CancellationToken ct);
    }
}
