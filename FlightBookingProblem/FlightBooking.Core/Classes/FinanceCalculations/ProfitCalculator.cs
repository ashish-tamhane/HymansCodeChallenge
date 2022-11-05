using System.Collections.Generic;

using FlightBooking.Core.Interfaces.FinanceCalculations;
using System.Linq;
using FlightBooking.Entities.Models;
using FlightBooking.Entities.Enumerations;

namespace FlightBooking.Core.Classes.FinanceCalculations
{
    public class ProfitCalculator : IProfitCalculator
    {
        public double CalculateProfit(IEnumerable<Passenger> passengerCollection, double basePrice)
        {
            return passengerCollection.Sum(p =>
                        p.Type == PassengerType.AirlineEmployee ? 0
                                                    : (p.Type == PassengerType.General ? basePrice
                                                                : (p.IsUsingLoyaltyPoints ? 0 : basePrice)));
        }
    }
}