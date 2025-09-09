namespace FlightBookingSystem.Domain.Domain
{
    public class Aircraft : BaseDomain
    {
        public string Name { get; set; }
        public string TailNumber { get; set; }
        public int SeatCapacity { get; set; }
    }
}
