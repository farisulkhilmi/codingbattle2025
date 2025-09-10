namespace FlightBookingSystem.Domain.Entities
{
    public class Aircraft : BaseDomain
    {
        public string Name { get; set; }
        public int SeatCapacity { get; set; }
    }
}
