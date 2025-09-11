using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateOrder
{
    public class CreateOrderCommanHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IFlightRouteRepository _flightRouteRepository;

        public CreateOrderCommanHandler(IOrderRepository orderRepository, IFlightRouteRepository flightRouteRepository)
        {
            _orderRepository = orderRepository;
            _flightRouteRepository = flightRouteRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var allFlightRoutes = _flightRouteRepository.GetAllFlightRoutesAsync(cancellationToken).Result.ToList();

            var flightRoute = allFlightRoutes.FirstOrDefault(
                fr => fr.Origin.Name.ToLower() == request.Origin.ToLower() &&
                      fr.Destination.Name.ToLower() == request.Destination.ToLower()
                );

            if (flightRoute != null)
            {
                int seatCapacity = flightRoute.Aircraft.SeatCapacity;
                int totalBooked = seatCapacity - flightRoute.SeatAvailibity;
                if (totalBooked >= seatCapacity)
                {
                    return Guid.Empty;
                }

                int currentNumber = totalBooked + 1;
                var bookingCode = flightRoute.Origin.DestinationCode + "-" + flightRoute.Destination.DestinationCode + "-" + currentNumber.ToString("D4");

                var order = new Order
                {
                    FlightRouteId = flightRoute.Id,
                    BookingCode = bookingCode,
                    ScheduledDay = flightRoute.ScheduledDay,
                    SeatNumber = currentNumber,
                    UserId = Guid.NewGuid(),
                    FlightRoute = flightRoute,
                    CreatedAt = DateTime.UtcNow
                };

                await _orderRepository.AddAsync(order, cancellationToken);
                return order.Id;
            }
            else { return Guid.Empty; }

        }
    }
}
