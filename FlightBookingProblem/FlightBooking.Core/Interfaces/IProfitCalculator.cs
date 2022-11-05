using FlightBooking.Core.Classes;
using System.Collections.Generic;
using FlightBooking.Core.Entities;

namespace FlightBooking.Core.Interfaces
{
    public interface IProfitCalculator
    {
        double CalculateProfit(IEnumerable<Passenger> passengerCollection, double basePrice);
    }

    public interface IProfitCalculatorII
    {
        double CalculateProfit(IScheduledFlight scheduledFlight);
    }
}