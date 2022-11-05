using FlightBooking.Core.Classes;
using System.Collections.Generic;
using FlightBooking.Core.Entities;

namespace FlightBooking.Core.Interfaces.FinanceCalculations
{
    public interface IProfitCalculator
    {
        double CalculateProfit(IEnumerable<Passenger> passengerCollection, double basePrice);
    }
}