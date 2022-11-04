using FlightBooking.Core.Interfaces;

namespace FlightBooking.Core.Classes
{
    public class Passenger : IPassenger
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int AllowedBags { get; set; }
        public int LoyaltyPoints { get; set; }
        public bool IsUsingLoyaltyPoints { get; set; }

        public PassengerType Type { get; set; }
    }
}
