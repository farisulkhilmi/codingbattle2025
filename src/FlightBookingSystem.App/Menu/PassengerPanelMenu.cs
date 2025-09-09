using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingSystem.App.Menu
{
    public class PassengerPanelMenu
    {
        public static void ShowPassengerPanel()
        {
            Console.Clear();
            Console.WriteLine("==== PASSENGER PANEL ====");
            Console.WriteLine();
            Console.Write("Enter passenger name: ");
            string? passengerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(passengerName))
            {
                Console.WriteLine("Passenger name cannot be empty. Please try again.");
            }
            else
            {
                Console.WriteLine($"Welcome, {passengerName}!");
            }

            Console.ReadKey();
        }
    }
}
