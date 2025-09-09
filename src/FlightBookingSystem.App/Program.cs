using FlightBookingSystem.App.Menu;
using FlightBookingSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Flight Booking System";

            try
            {
                checkDbConnection();

                LoginMenu.ShowLogin();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        private static void checkDbConnection()
        {
            try
            {
                var dbBuilder = new DbContextOptionsBuilder<AppDbContext>();
                dbBuilder.UseSqlite("Data Source=flightbooking.db");

                using var dbContext = new AppDbContext(dbBuilder.Options);

                Console.WriteLine("Initializing database...");
                dbContext.Database.EnsureCreated();

                var canConnect = dbContext.Database.CanConnect();

                if (canConnect)
                {
                    Console.WriteLine("Database initialized successfully.");
                }
                else
                {
                    throw new Exception("Unable to connect to the database.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}