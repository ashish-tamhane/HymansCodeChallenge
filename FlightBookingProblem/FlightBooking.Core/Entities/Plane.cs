using FlightBooking.Core.Interfaces;

namespace FlightBooking.Core.Entities
{
    public struct Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
