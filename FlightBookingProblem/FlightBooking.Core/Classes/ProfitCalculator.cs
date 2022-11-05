using FlightBooking.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.Classes
{
    public class ProfitCalculator : IProfitCalculator
    {
        public double CalculateProfit(IEnumerable<IPassenger> passengerCollection, double basePrice)
        {
            return passengerCollection.Sum(p =>
                        p.Type == PassengerType.AirlineEmployee ? 0
                                                    : (p.Type == PassengerType.General ? basePrice
                                                                : (p.IsUsingLoyaltyPoints ? 0 : basePrice)));
        }
    }

    public class ProfitCalculatorII : IProfitCalculatorII
    {
        public double CalculateProfit(IScheduledFlight scheduledFlight)
        {
            return scheduledFlight.Passengers.Sum(p =>
                        p.Type == PassengerType.AirlineEmployee ? 0
                                                    : (p.Type == PassengerType.General ? scheduledFlight.FlightRoute.BasePrice
                                                                : (p.IsUsingLoyaltyPoints ? 0 : scheduledFlight.FlightRoute.BasePrice)));
        }
    }
}