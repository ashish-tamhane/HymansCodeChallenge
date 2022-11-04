namespace FlightBooking.Core.Interfaces
{
    public interface ILoyaltyPointsCalculator
    {
        bool CalculateLoyaltyPoints(IPassenger passenger, IFlightRoute flightRoute, out int totalLoyaltyPointsRedeemed, out int totalLoyaltyPointsAccrued);
    }
}