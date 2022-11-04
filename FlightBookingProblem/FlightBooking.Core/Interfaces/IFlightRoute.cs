namespace FlightBooking.Core.Interfaces
{
    public interface IFlightRoute
    {
        double BaseCost { get; set; }
        double BasePrice { get; set; }
        int LoyaltyPointsGained { get; set; }
        double MinimumTakeOffPercentage { get; set; }
        string Title { get; }
    }
}