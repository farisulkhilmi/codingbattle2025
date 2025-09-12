using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Application.Abstractions
{
    public interface ISystemSettingRepository
    {
        Task<int> GetSettingAsync(string key, CancellationToken ct);
        Task SetSettingAsync(SystemSetting setting, CancellationToken ct);
        Task UpdateSettingAsync(string key, int value, CancellationToken ct);
    }
}
