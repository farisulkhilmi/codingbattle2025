using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingSystem.App.Menu
{
    public class AdminPanelMenu
    {
        public static void ShowAdminPanel()
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

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
        }
    }
}
