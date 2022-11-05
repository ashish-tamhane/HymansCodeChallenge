namespace FlightBooking.Core.Interfaces
{
    public interface IFlightFinance
    {
        double CostOfFlight();
        double ProfitFromFlight();
        double ProfitSurplus();
    }
}