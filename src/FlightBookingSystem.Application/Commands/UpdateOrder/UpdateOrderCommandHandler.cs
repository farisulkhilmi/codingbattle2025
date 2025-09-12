using FlightBookingSystem.Application.Abstractions;
using MediatR;

namespace FlightBookingSystem.Application.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Guid>
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IUnitOfWork uow, IOrderRepository orderRepository)
        {
            _uow = uow;
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(UpdateOrderCommand request, CancellationToken ct)
        {
            var order = await _orderRepository.GetOrderByBookingCode(request.BookingCode, ct);

            if (order != null)
            {
                order.IsDeleted = true;
                order.UpdatedAt = DateTime.UtcNow;

                try
                {
                    await _orderRepository.UpdateOrderAsync(order, ct);
                    await _uow.SaveChangesAsync(ct);

                    return order.Id;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return Guid.Empty;
                }

            }
            else
            {
                return Guid.Empty;
            }

        }
    }
}
