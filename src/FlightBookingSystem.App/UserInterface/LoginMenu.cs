using FlightBookingSystem.App.UserInterface.Contracts;

namespace FlightBookingSystem.App.UserInterface
{
    public sealed class LoginMenu : ILoginMenu
    {
        private readonly IAdminPanel _admin;
        private readonly IPassengerPanel _passenger;

        public LoginMenu(IAdminPanel admin, IPassengerPanel passenger)
        { 
            _admin = admin; 
            _passenger = passenger; 
        }

        public void Show()
        {
            Console.WriteLine("=== Welcome to the Dang Goreng Airline Booking System! ===");
            Console.WriteLine();
            Console.WriteLine("Login as:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Passenger");

            var key = Console.ReadKey();
            Console.WriteLine();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1: 
                    _admin.Show(); 
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2: 
                    _passenger.Show(); 
                    break;
                default: 
                    Console.WriteLine("Invalid Input."); 
                    break;
            }
        }
    }
}
