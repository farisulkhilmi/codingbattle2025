using FlightBookingSystem.Domain.Entities;

namespace FlightBookingSystem.Domain.Dto
{
    public class OrderFlightResult
    {
        public bool IsTransit { get; set; }

        public Order? Order1 { get; set; }
        public Order? Order2 { get; set; }
    }
}
