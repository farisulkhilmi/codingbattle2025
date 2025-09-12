using FlightBookingSystem.App.UserInterface.Contracts;
using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Application.Commands.CreateSystemSetting;
using FlightBookingSystem.Application.Commands.UpdateSystemSetting;
using FlightBookingSystem.Application.Queries.GetSystemSettingByKey;
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
        private readonly ICancelOrder _cancelOrder;
        public LoginMenu(IMediator mediator, IRegisterAircraft regAircraft, IRegisterDestination regDestination, IOrderFlight orderFlight, IRegisterFlightRoute registerFlightRoute, ICancelOrder cancelOrder)
        {
            _mediator = mediator;
            _regAircraft = regAircraft;
            _regDestination = regDestination;
            _orderFlight = orderFlight;
            _registerFlightRoute = registerFlightRoute;
            _cancelOrder = cancelOrder;
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
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        RunBookingService();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        GoToNextDay();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        //_registerFlightRoute.Show();
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

        private void RunBookingService()
        {
            var cmd = new UpdateSystemSettingCommand();
            cmd.Key = Contants.BookingSystemStatus;
            cmd.Value = 1;
            var result = _mediator.Send(cmd);
            if (result.Result == "Success")
            {
                Console.WriteLine("Booking Service is now running.");
                Console.WriteLine("Press any key to back.");
                Console.ReadKey();
                ShowAdminPanel();
            }
            else
            {
                Console.WriteLine("Failed to run Booking Service.");
                Console.WriteLine("Press any key to back.");
                Console.ReadKey();
                ShowAdminPanel();
            }
        }

        private void GoToNextDay()
        {
            Console.WriteLine("Advancing to the next day...");

            var cmdGetCalender = new GetSystemSettingByKeyQuery();
            cmdGetCalender.Key = Contants.Calender;
            var currentDay = _mediator.Send(cmdGetCalender).Result;

            var cmd = new UpdateSystemSettingCommand();
            cmd.Key = Contants.Calender;
            cmd.Value = currentDay + 1;
            var result = _mediator.Send(cmd);
            if (result.Result == "Success")
            {
                Console.WriteLine($"Current day is now: {currentDay + 1}");
                Console.WriteLine("Press any key to back.");
                Console.ReadKey();
                ShowAdminPanel();
            }
            else
            {
                Console.WriteLine("Failed to advancing to next day.");
                Console.WriteLine("Press any key to back.");
                Console.ReadKey();
                ShowAdminPanel();
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
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        _cancelOrder.Show();
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }
    }
}
