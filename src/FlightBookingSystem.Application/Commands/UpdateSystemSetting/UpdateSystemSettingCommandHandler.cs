using FlightBookingSystem.Application.Abstractions;
using MediatR;

namespace FlightBookingSystem.Application.Commands.UpdateSystemSetting
{
    public class UpdateSystemSettingCommandHandler : IRequestHandler<UpdateSystemSettingCommand>
    {
        private readonly ISystemSettingRepository _repo;
        private readonly IUnitOfWork _uow;

        public UpdateSystemSettingCommandHandler(ISystemSettingRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task Handle(UpdateSystemSettingCommand request, CancellationToken cancellationToken)
        {
            await _repo.UpdateSettingAsync(request.Key, request.Value, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
        }
    }
}
