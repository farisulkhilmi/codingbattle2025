using FlightBookingSystem.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystem.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<FlightRoute> FlightRoutes { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source = flightbooking.db");
        }
    }
}
