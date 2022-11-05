using FlightBooking.Entities;

namespace FlightBooking.Entities.Models
{
    public struct Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
