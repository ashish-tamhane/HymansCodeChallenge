using FlightBooking.Core.Classes;

namespace FlightBooking.Core.Interfaces
{
    public interface IPassenger
    {
        int Age { get; set; }
        int AllowedBags { get; set; }
        bool IsUsingLoyaltyPoints { get; set; }
        int LoyaltyPoints { get; set; }
        string Name { get; set; }
        PassengerType Type { get; set; }
    }
}