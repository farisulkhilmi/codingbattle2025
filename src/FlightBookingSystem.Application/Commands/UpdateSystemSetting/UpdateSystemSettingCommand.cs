using FlightBookingSystem.Domain.Dto;
using MediatR;

namespace FlightBookingSystem.Application.Commands.UpdateSystemSetting
{
    public class UpdateSystemSettingCommand : Setting, IRequest
    {
    }
}
