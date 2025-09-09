namespace FlightBookingSystem.Domain.Entities
{
    public class User : BaseDomain
    {
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
