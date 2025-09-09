namespace FlightBookingSystem.Domain.Domain
{
    public class Order : BaseDomain
    {
        public string BookingCode { get; set; }
        public Guid UserId { get; set; }
        public Guid FlightRouteId { get; set; }
        public FlightRoute FlightRoute { get; set; }
        public int ScheduledDay { get; set; }
        public int SeatNumber { get; set; }
    }
}
