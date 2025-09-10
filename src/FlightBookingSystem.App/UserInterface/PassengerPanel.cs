using FlightBookingSystem.App.UserInterface.Contracts;

namespace FlightBookingSystem.App.UserInterface
{
    public sealed class PassengerPanel : IPassengerPanel
    {
        public void Show()
        {
            Console.WriteLine("=== Passenger Panel ===");
            Console.WriteLine("(TODO) Search flights, pick seat, etc.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
        }
    }
}
