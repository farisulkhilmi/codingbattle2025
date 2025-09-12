using FlightBookingSystem.Application.Abstractions;
using MediatR;

namespace FlightBookingSystem.Application.Commands.UpdateSystemSetting
{
    public class UpdateSystemSettingCommandHandler : IRequestHandler<UpdateSystemSettingCommand, string>
    {
        private readonly ISystemSettingRepository _repo;
        private readonly IUnitOfWork _uow;

        public UpdateSystemSettingCommandHandler(ISystemSettingRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<string> Handle(UpdateSystemSettingCommand request, CancellationToken cancellationToken)
        {
            var setting = await _repo.UpdateSettingAsync(request.Key, request.Value, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            if (setting.Value == request.Value)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }
    }
}
