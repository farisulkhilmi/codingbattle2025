using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Dto;
using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateOrder
{
    public class CreateOrderCommanHandler : IRequestHandler<CreateOrderCommand, OrderFlightResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRouteRepository _flightRouteRepository;
        private readonly IUnitOfWork _uow;

        public CreateOrderCommanHandler(IOrderRepository orderRepository, IFlightRouteRepository flightRouteRepository, IUnitOfWork uow)
        {
            _orderRepository = orderRepository;
            _flightRouteRepository = flightRouteRepository;
            _uow = uow;
        }

        public async Task<OrderFlightResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var allFlightRoutes = _flightRouteRepository.GetAllFlightRoutesAsync(cancellationToken).Result.ToList();
            var userIdTemp = Guid.NewGuid();

            //direct flight

            var directFlight = allFlightRoutes.FirstOrDefault(
                fr => fr.Origin.Name.ToLower() == request.Origin.ToLower() &&
                      fr.Destination.Name.ToLower() == request.Destination.ToLower()
                );

            if (directFlight != null)
            {
                var order1 = await OrderFlight(directFlight, userIdTemp, cancellationToken);

                if (order1 == null)
                    return new OrderFlightResult { IsTransit = false, Order1 = null };

                return new OrderFlightResult { IsTransit = false, Order1 = order1 };
            }

            //transit flight

            var destinationFlight = allFlightRoutes.FirstOrDefault(fr => fr.Destination.Name.ToLower() == request.Destination.ToLower());
            if (destinationFlight == null)
                return new OrderFlightResult { IsTransit = true, Order1 = null, Order2 = null };
            var originFlight = allFlightRoutes.FirstOrDefault(fr => fr.Origin.Name.ToLower() == request.Origin.ToLower() && fr.Destination.Name.ToLower() == destinationFlight.Origin.Name.ToLower());
            if (originFlight == null)
                return new OrderFlightResult { IsTransit = true, Order1 = null, Order2 = null };
            var orderTransit1 = await OrderFlight(originFlight, userIdTemp, cancellationToken);
            if (orderTransit1 == null)
                return new OrderFlightResult { IsTransit = true, Order1 = null, Order2 = null };
            var orderTransit2 = await OrderFlight(destinationFlight, userIdTemp, cancellationToken);
            if (orderTransit2 == null)
                return new OrderFlightResult { IsTransit = true, Order1 = null, Order2 = null };
            return new OrderFlightResult { IsTransit = true, Order1 = orderTransit1, Order2 = orderTransit2 };


        }

        private async Task<Order> OrderFlight(FlightRoute flightRoute, Guid userId, CancellationToken cancellationToken)
        {
            int seatCapacity = flightRoute.Aircraft.SeatCapacity;
            int totalBooked = seatCapacity - flightRoute.SeatAvailibity;
            if (totalBooked >= seatCapacity)
            {
                return null;
            }
            int currentNumber = totalBooked + 1;
            var bookingCode = flightRoute.Origin.DestinationCode + "-" + flightRoute.Destination.DestinationCode + "-" + currentNumber.ToString("D4");

            var order = new Order
            {
                FlightRouteId = flightRoute.Id,
                BookingCode = bookingCode,
                ScheduledDay = flightRoute.ScheduledDay,
                SeatNumber = currentNumber,
                UserId = userId,
                FlightRoute = flightRoute,
                CreatedAt = DateTime.UtcNow
            };
            await _orderRepository.AddAsync(order, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return order;
        }
    }
}
