using FlightBooking.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core
{
    public class BaggageCalculator : IBaggageCalculator
    {
        public int CalculateBaggage(List<IPassenger> passengers)
        {
            return passengers.Sum(p => { return p.Type == PassengerType.LoyaltyMember ? 2 : 1; });
        }
    }
}