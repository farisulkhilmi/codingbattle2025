using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.Commands.CreateAircraft;
using MediatR;

namespace FlightBookingSystem.App.UserInterface
{
    public sealed class RegisterAircraft : IRegisterAircraft
    {
        private readonly IMediator _mediator;

        public RegisterAircraft(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("== Register Aircraft ==");
            Console.Write("Enter Aircraft Name: ");
            string? aircraftName = Console.ReadLine();

            int seatCapacityValue;
            while (true)
            {
                Console.Write("Enter Seat Capacity: ");
                string? seatCapacity = Console.ReadLine();

                if (int.TryParse(seatCapacity, out seatCapacityValue) && seatCapacityValue > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }

            Console.WriteLine("Are you sure want to insert this data?");
            Console.WriteLine($"Aircraft Name: {aircraftName}");
            Console.WriteLine($"Seat Capacity: {seatCapacityValue}");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine();
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    var _ = RegisterAircraftCommand(aircraftName, seatCapacityValue);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                default:
                    Console.WriteLine("Invalid Input.");
                    break;
            }
        }

        private async Task RegisterAircraftCommand(string aircraftName, int seatCapacity)
        {
            var cmd = new CreateAircraftCommand();
            cmd.Name = aircraftName;
            cmd.SeatCapacity = seatCapacity;

            var result = await _mediator.Send(cmd);

            if (result != Guid.Empty)
            {
                Console.WriteLine($"{aircraftName} with {seatCapacity} registered successfully!");
                Console.WriteLine("Please press any key to back!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed to register aircraft.");
                Console.ReadKey();
            }
        }
    }
}
