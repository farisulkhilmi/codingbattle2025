using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.Commands.CreateFlightRoute;
using MediatR;

namespace FlightBookingSystem.App.UserInterface
{
    public class RegisterFlightRoute : IRegisterFlightRoute
    {
        private readonly IMediator _mediator;
        public RegisterFlightRoute(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Register Flight ===");
            Console.WriteLine("Enter Origin City: ");
            string? originCity = Console.ReadLine();

            Console.WriteLine("Enter Destination City: ");
            string? destinationCity = Console.ReadLine();

            Console.WriteLine("Enter Aircraft Name: ");
            string? aircraftName = Console.ReadLine();

            int scheduledDayValue;
            while (true)
            {
                Console.WriteLine("Enter Scheduled Day (e.g., 1, 2): ");
                string? scheduledDay = Console.ReadLine();
                if (int.TryParse(scheduledDay, out scheduledDayValue) && scheduledDayValue > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }

            Console.WriteLine("Are you sure want to insert this data?");
            Console.WriteLine($"Origin City: {originCity}");
            Console.WriteLine($"Destination City: {destinationCity}");
            Console.WriteLine($"Aircraft Name: {aircraftName}");
            Console.WriteLine($"Scheduled Day: {scheduledDayValue}");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine();
                    var _ = RegisterFlightCommand(originCity, destinationCity, aircraftName, scheduledDayValue);
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

        private async Task RegisterFlightCommand(string originCity, string destinationCity, string aircraftName, int scheduledDayValue)
        {
            var cmd = new CreateFlightRouteCommand();
            cmd.OriginCity = originCity;
            cmd.DestinationCity = destinationCity;
            cmd.AircraftName = aircraftName;
            cmd.ScheduledDay = scheduledDayValue;

            var result = await _mediator.Send(cmd);
            if (result != Guid.Empty)
            {
                Console.WriteLine("Flight registered successfully.");
                Console.WriteLine("Please press any key to back!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed to register flight. Please check the details and try again.");
                Console.ReadKey();
            }
        }
    }
}
