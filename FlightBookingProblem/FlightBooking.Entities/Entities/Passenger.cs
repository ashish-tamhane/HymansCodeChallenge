using FlightBooking.Entities.Enumerations;

namespace FlightBooking.Entities.Models
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
