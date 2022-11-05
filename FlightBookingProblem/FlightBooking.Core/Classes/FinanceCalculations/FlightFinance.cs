using FlightBooking.Core.Interfaces;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using System.Linq;

namespace FlightBooking.Core.Classes.FinanceCalculations
{
    public class FlightFinance : IFlightFinance
    {
        private readonly IScheduledFlight scheduledFlight;
        private IFlightRoute flightRoute;
        private IProfitCalculator profitCalculator;
        
        public FlightFinance(IScheduledFlight scheduledFlight, IFlightRoute flightRoute, IProfitCalculator profitCalculator)
        {
            this.scheduledFlight = scheduledFlight;
            this.flightRoute = flightRoute;
            this.profitCalculator = profitCalculator;
        }

        public double CostOfFlight() => scheduledFlight.Passengers.Sum(p => flightRoute.BaseCost);

        public double ProfitFromFlight() => profitCalculator.CalculateProfit(scheduledFlight.Passengers, flightRoute.BasePrice);

        public double ProfitSurplus() => ProfitFromFlight() - CostOfFlight();
    }
}