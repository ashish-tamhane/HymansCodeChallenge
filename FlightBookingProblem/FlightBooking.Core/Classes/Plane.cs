using FlightBooking.Core.Interfaces;

namespace FlightBooking.Core.Classes
{
    public class Plane : IPlane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
