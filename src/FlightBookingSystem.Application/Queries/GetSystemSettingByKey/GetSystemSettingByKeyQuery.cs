using MediatR;

namespace FlightBookingSystem.Application.Queries.GetSystemSettingByKey
{
    public class GetSystemSettingByKeyQuery : IRequest<int>
    {
        public string Key { get; set; } = string.Empty;
    }
}
