
using FlightBooking.Core.Interfaces;
using FlightBooking.Entities.Models;
using FlightBooking.Entities.Enumerations;
using System.Collections.Generic;
using System.Linq;


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