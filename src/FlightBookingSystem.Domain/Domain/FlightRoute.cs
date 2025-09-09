namespace FlightBookingSystem.Domain.Domain
{
    public class FlightRoute : BaseDomain
    {
        public string FlightNumber { get; set; }
        public Guid OriginId { get; set; }
        public Destination Origin { get; set; }
        public Guid DestinationId { get; set; }
        public Destination Destination { get; set; }
        public Guid AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }
        public int ScheduledDay { get; set; }
    }
}
