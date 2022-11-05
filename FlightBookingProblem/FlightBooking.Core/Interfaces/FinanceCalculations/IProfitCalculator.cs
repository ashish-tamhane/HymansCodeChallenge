using FlightBooking.Entities.Models;
using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces.FinanceCalculations
{
    public interface IProfitCalculator
    {
        double CalculateProfit(IEnumerable<Passenger> passengerCollection, double basePrice);
    }
}