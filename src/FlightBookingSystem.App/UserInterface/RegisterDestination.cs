using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.Commands.CreateDestination;
using MediatR;

namespace FlightBookingSystem.App.UserInterface
{
    public class RegisterDestination : IRegisterDestination
    {
        private readonly IMediator _mediator;
        public RegisterDestination(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("== Register Destination ==");
            Console.Write("Enter Destination City: ");
            string? destinationName = Console.ReadLine();
            string? destinationCode = destinationName?.Substring(0, 3).ToUpper();
            Console.WriteLine("Are you sure want to insert this data?");
            Console.WriteLine($"Destination Name: {destinationName}");
            Console.WriteLine($"Destination Code: {destinationCode}");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine();
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    var _ = RegisterDestinationCommand(destinationName, destinationCode);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                default:
                    Console.WriteLine("Invalid Input.");
                    break;
            }
        }

        private async Task RegisterDestinationCommand(string destinationName, string destinationCode)
        {
            var cmd = new CreateDestinationCommand();
            cmd.Name = destinationName;
            cmd.DestinationCode = destinationCode;

            var result = await _mediator.Send(cmd);



            if (result != Guid.Empty)
            {
                Console.WriteLine();
                Console.WriteLine($"Destination city {destinationName} with Code {destinationCode} registered Successfully.");
                Console.WriteLine("Please press any key to back!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Destination city {destinationName} already exist.");
                Console.ReadKey();
            }
        }
    }
}
