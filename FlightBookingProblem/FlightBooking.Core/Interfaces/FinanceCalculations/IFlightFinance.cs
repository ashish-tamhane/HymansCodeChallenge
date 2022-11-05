namespace FlightBooking.Core.Interfaces.FinanceCalculations
{
    public interface IFlightFinance
    {
        double CostOfFlight();
        double ProfitFromFlight();
        double ProfitSurplus();
    }
}