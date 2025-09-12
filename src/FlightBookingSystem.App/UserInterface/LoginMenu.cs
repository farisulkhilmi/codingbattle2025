using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.Commands.CreateSystemSetting;
using FlightBookingSystem.Domain.Constant;
using FlightBookingSystem.Domain.Dto;
using MediatR;

namespace FlightBookingSystem.App.UserInterface
{
    public sealed class LoginMenu : ILoginMenu
    {
        private readonly IMediator _mediator;
        private readonly IRegisterAircraft _regAircraft;
        private readonly IRegisterDestination _regDestination;
        private readonly IOrderFlight _orderFlight;
        private readonly IRegisterFlightRoute _registerFlightRoute;
        public LoginMenu(Mediator mediator, IRegisterAircraft regAircraft, IRegisterDestination regDestination, IOrderFlight orderFlight, IRegisterFlightRoute registerFlightRoute)
        {
            _mediator = mediator;
            _regAircraft = regAircraft;
            _regDestination = regDestination;
            _orderFlight = orderFlight;
            _registerFlightRoute = registerFlightRoute;
        }

        public void Show()
        {
            InitiateSystem();

            Console.Clear();
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
                    ShowAdminPanel();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowPassengerPanel();
                    break;
                default:
                    Console.WriteLine("Invalid Input.");
                    break;
            }
        }

        private void InitiateSystem()
        {
            var settingCalender = new Setting
            {
                Key = Contants.Calender,
                Value = 1
            };

            var settingBookingSystemStatus = new Setting
            {
                Key = Contants.BookingSystemStatus,
                Value = 0
            };

            var cmdSetting = new CreateSystemSettingCommand();
            cmdSetting.Settings = new List<Setting> { settingCalender, settingBookingSystemStatus };

            var _ = _mediator.Send(cmdSetting);
        }

        private void ShowAdminPanel()
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
                        _regDestination.Show();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        _registerFlightRoute.Show();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        Show();
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

        private void ShowPassengerPanel()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Passenger Panel ===");
                Console.WriteLine();
                Console.WriteLine("1. Order Flight");
                Console.WriteLine("2. Cancel Flight");
                Console.WriteLine();
                Console.WriteLine("0. Exit");

                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        Show();
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        _orderFlight.Show();
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }
    }
}
