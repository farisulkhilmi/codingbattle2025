using FlightBookingSystem.App.UserInterface.Contracts;
using MediatR;

namespace FlightBookingSystem.App.UserInterface
{
    public sealed class AdminPanel : IAdminPanel
    {
        private readonly IMediator _mediator;
        private readonly IRegisterAircraft _regAircraft;

        public AdminPanel(IMediator mediator, IRegisterAircraft regAircraft)
        {
            _mediator = mediator;
            _regAircraft = regAircraft;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== ADMIN PANEL ====");
                Console.WriteLine();
                Console.WriteLine("1. Register Aircraft");
                Console.WriteLine("2. Add Destination");
                Console.WriteLine("3. Create Flight Route");
                Console.WriteLine("4. Run Booking Service");
                Console.WriteLine("5. Go to Next Day");
                Console.WriteLine("6. Run Flight");
                Console.WriteLine("7. Exit");

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        _regAircraft.Show();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }
    }
}
