using FlightBookingSystem.Domain.Dto;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateOrder
{
    public class CreateOrderCommand : OrderRequestDto, IRequest<OrderFlightResult>
    {
    }
}
