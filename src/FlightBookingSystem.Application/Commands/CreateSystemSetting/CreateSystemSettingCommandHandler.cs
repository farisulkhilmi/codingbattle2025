using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateSystemSetting
{
    public class CreateSystemSettingCommandHandler : IRequestHandler<CreateSystemSettingCommand>
    {
        private readonly ISystemSettingRepository _repo;
        private readonly IUnitOfWork _uow;

        public CreateSystemSettingCommandHandler(ISystemSettingRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }
        public async Task Handle(CreateSystemSettingCommand request, CancellationToken cancellationToken)
        {
            foreach (var setting in request.Settings)
            {
                var systemSetting = new SystemSetting 
                {
                    Name = setting.Key,
                    Value = int.Parse(setting.Value),
                    CreatedAt = DateTime.UtcNow
                };

                await _repo.SetSettingAsync(systemSetting, cancellationToken);
                await _uow.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
