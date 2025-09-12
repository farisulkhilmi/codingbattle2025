using FlightBookingSystem.Domain.Dto;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateSystemSetting
{
    public class CreateSystemSettingCommand : SystemSettingsDto, IRequest
    {
    }
}
