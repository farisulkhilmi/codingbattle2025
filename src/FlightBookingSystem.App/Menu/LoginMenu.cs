using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingSystem.App.Menu
{
    public class LoginMenu
    {
        public static void ShowLogin()
        {
            Console.WriteLine("=== Welcome to the Dang Goreng Airline Booking System! ===");
            Console.WriteLine();
            Console.WriteLine("Login as:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Passenger");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();

            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                AdminPanelMenu.ShowAdminPanel();
            }
            else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
            {
                PassengerPanelMenu.ShowPassengerPanel();
            }
            else
            {
                Console.WriteLine("Invalid selection. Exiting application.");
            }
        }
    }
}
