namespace FlightBookingSystem.Domain.Dto
{
    public class FlightRouteDto
    {
        public string FligthNumber { get; set; }
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public string AircraftName { get; set; }
        public int ScheduledDay { get; set; }
    }
}
