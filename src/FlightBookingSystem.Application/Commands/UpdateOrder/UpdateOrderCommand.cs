using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Commands.UpdateOrder
{
    public class UpdateOrderCommand : Order, IRequest<Guid>
    {
    }
}
