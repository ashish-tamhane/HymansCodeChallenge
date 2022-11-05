using FlightBooking.Core.Interfaces;
using FlightBooking.Core.Enumerations;

namespace FlightBooking.Core.Entities
{
    public struct Passenger
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int AllowedBags { get; set; }
        public int LoyaltyPoints { get; set; }
        public bool IsUsingLoyaltyPoints { get; set; }

        public PassengerType Type { get; set; }
    }
}
