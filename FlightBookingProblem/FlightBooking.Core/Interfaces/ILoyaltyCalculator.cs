using FlightBooking.Core.Classes;
using FlightBooking.Core.Entities;

namespace FlightBooking.Core.Interfaces
{
    public interface ILoyaltyPointsCalculator
    {
        bool CalculateLoyaltyPoints(Passenger passenger, FlightRoute flightRoute, out int totalLoyaltyPointsRedeemed, out int totalLoyaltyPointsAccrued);
    }
}