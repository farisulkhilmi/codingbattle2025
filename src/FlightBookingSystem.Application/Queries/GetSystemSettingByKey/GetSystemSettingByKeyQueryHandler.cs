using FlightBookingSystem.Application.Abstractions;
using MediatR;

namespace FlightBookingSystem.Application.Queries.GetSystemSettingByKey
{
    public class GetSystemSettingByKeyQueryHandler : IRequestHandler<GetSystemSettingByKeyQuery, int>
    {
        private readonly ISystemSettingRepository _repo;
        private readonly IUnitOfWork _uow;

        public GetSystemSettingByKeyQueryHandler(ISystemSettingRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public Task<int> Handle(GetSystemSettingByKeyQuery request, CancellationToken cancellationToken)
        {
            var setting = _repo.GetSettingAsync(request.Key, cancellationToken);
            
            return setting;
        }
    }
}
