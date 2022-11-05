using FlightBooking.Core.Interfaces;
using System.Collections.Generic;
using FlightBooking.Core.Entities;
using FlightBooking.Core.Enumerations;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using System.Linq;

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