using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Application.Abstractions
{
    public interface ISystemSettingRepository
    {
        Task<int> GetSettingAsync(string key, CancellationToken ct);
        Task SetSettingAsync(SystemSetting setting, CancellationToken ct);
        Task<SystemSetting> UpdateSettingAsync(string key, int value, CancellationToken ct);
    }
}
