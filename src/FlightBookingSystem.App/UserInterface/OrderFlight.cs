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

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("== Order Flight ==");
            GetAllFlightRouteCommand().Wait();
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


        private async Task GetAllFlightRouteCommand()
        {
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
        }

        private async Task OrderFlightCommand(string originCity, string destinationCity)
        {

            var cmd = new CreateOrderCommand();
            cmd.Origin = originCity;
            cmd.Destination = destinationCity;
            var result = await _mediator.Send(cmd);
            if (result != Guid.Empty)
            {
                Console.WriteLine($"Order created successfully! Your Order ID is: {result}");
            }
            else
            {
                Console.WriteLine("Failed to create order. Please check the origin and destination cities.");
            }
        }


    }
}
