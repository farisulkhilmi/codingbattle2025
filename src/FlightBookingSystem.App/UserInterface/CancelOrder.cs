using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.Commands.UpdateOrder;
using MediatR;

namespace FlightBookingSystem.App.UserInterface
{
    public class CancelOrder : ICancelOrder
    {
        private readonly IMediator _mediator;
        public CancelOrder(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Cancel Flight ===");
            Console.Write("Enter Booking Code: ");
            string bookingCode = Console.ReadLine();
            Console.WriteLine("Are you sure want to cancel this order?");
            Console.WriteLine($"Booking Code: {bookingCode}");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine();
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine();
                    var _ = CancelOrderCommand(bookingCode);
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

        private async Task CancelOrderCommand(string bookingCode)
        {
            var cmd = new UpdateOrderCommand();
            cmd.BookingCode = bookingCode;
            var result = await _mediator.Send(cmd);

            if (result != Guid.Empty)
            {
                Console.WriteLine();
                Console.WriteLine($"Your order with Booking Code ${bookingCode} has been canceled.");
                Console.WriteLine("Please press any key to back!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Can't find your order.");
                Console.WriteLine("Please press any key to back!");
                Console.ReadKey();
            }
        }
    }
}
