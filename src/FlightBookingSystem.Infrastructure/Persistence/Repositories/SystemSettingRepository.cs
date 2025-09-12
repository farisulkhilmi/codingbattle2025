using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Infrastructure.Persistence.Repositories
{
    public class SystemSettingRepository : ISystemSettingRepository
    {
        private readonly ApplicationDbContext _db;

        public SystemSettingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> GetSettingAsync(string key, CancellationToken ct)
        {
            var setting = await _db.SystemSettings.FirstOrDefaultAsync(s => s.Name == key, ct);

            return setting.Value;
        }

        public async Task SetSettingAsync(SystemSetting setting, CancellationToken ct)
        {
            await _db.SystemSettings.AddAsync(setting, ct);
        }

        public async Task UpdateSettingAsync(string key, int value, CancellationToken ct)
        {
            var setting = await _db.SystemSettings.FirstOrDefaultAsync(s => s.Name == key, ct);
            if (setting != null)
            {
                setting.Value = value;
            }
            _db.SystemSettings.Update(setting);
        }
    }
}
