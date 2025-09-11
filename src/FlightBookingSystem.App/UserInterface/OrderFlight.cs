using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Application.Commands.CreateOrder;
using MediatR;

namespace FlightBookingSystem.App.UserInterface
{
    public class OrderFlight : IOrderFlight
    {
        private readonly IMediator _mediator;
        private readonly IFlightRouteRepository _flightRouteRepository;
        public OrderFlight(IMediator mediator, IFlightRouteRepository flightRouteRepository)
        {
            _mediator = mediator;
            _flightRouteRepository = flightRouteRepository;
        }

        public async Task Show()
        {
            Console.Clear();
            Console.WriteLine("== Order Flight ==");

            var flightRoutes = await _flightRouteRepository.GetAllFlightRoutesAsync(default);

            if (flightRoutes.Any())
            {
                Console.WriteLine("List of Flight Routes:");
                foreach (var flightRoute in flightRoutes)
                {
                    Console.WriteLine($"- {flightRoute.Origin.Name} to {flightRoute.Destination.Name} | Aircraft: {flightRoute.Aircraft.Name} | Scheduled Day: {flightRoute.ScheduledDay} | Seat Availability: {flightRoute.SeatAvailibity}");
                }
            }
            else
            {
                Console.WriteLine("No flight routes available.");
            }

            Console.Write("Enter Origin City: ");
            string? originCity = Console.ReadLine();
            Console.Write("Enter Destination City: ");
            string? destinationCity = Console.ReadLine();
            Console.WriteLine("Are you sure want to insert this data?");
            Console.WriteLine($"Origin City: {originCity}");
            Console.WriteLine($"Destination City: {destinationCity}");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine();
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine();
                    var _ = OrderFlightCommand(originCity, destinationCity);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Show();
                    break;
                default:
                    Console.WriteLine("Invalid Input.");
                    break;
            }
        }

        private async Task OrderFlightCommand(string originCity, string destinationCity)
        {

            var cmd = new CreateOrderCommand();
            cmd.Origin = originCity;
            cmd.Destination = destinationCity;
            var result = await _mediator.Send(cmd);
            if (result.Order1 != null)
            {
                if (result.IsTransit && result.Order2 != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Your flight includes a transit.");
                    Console.WriteLine($"First Leg: {result.Order1.FlightRoute.Origin.Name} to {result.Order1.FlightRoute.Destination.Name} | Aircraft: {result.Order1.FlightRoute.Aircraft.Name} | Seat: {result.Order1.BookingCode.Split('-')[2].TrimStart('0')} | Scheduled Day: {result.Order1.FlightRoute.ScheduledDay}");
                    Console.WriteLine($"Second Leg: {result.Order2.FlightRoute.Origin.Name} to {result.Order2.FlightRoute.Destination.Name} | Aircraft: {result.Order2.FlightRoute.Aircraft.Name} | Seat: {result.Order2.BookingCode.Split('-')[2].TrimStart('0')} | Scheduled Day: {result.Order2.FlightRoute.ScheduledDay}");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You have a direct flight.");
                    Console.WriteLine($"Flight: {result.Order1.FlightRoute.Origin.Name} to {result.Order1.FlightRoute.Destination.Name} | Aircraft: {result.Order1.FlightRoute.Aircraft.Name} | Seat: {result.Order1.BookingCode.Split('-')[2].TrimStart('0')} | Scheduled Day: {result.Order1.FlightRoute.ScheduledDay}");
                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Failed to create order. Please check the origin and destination cities.");
                Console.WriteLine("Please press any key to back!");
                Console.ReadKey();
            }
        }


    }
}
