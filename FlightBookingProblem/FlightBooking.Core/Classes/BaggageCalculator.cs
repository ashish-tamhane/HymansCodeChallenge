using FlightBooking.Core.Entities;
using FlightBooking.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using FlightBooking.Core.Enumerations;

namespace FlightBooking.Core.Classes
{
    public class BaggageCalculator : IBaggageCalculator
    {
        public int CalculateBaggage(List<Passenger> passengers)
        {
            return passengers.Sum(p => { return p.Type == PassengerType.LoyaltyMember ? 2 : 1; });
        }
    }
}