
using FlightBooking.Entities.Models;
using FlightBooking.Entities.Enumerations;
using System.Collections.Generic;
using System.Linq;
using FlightBooking.BaggageCalculator.Interfaces;

namespace FlightBooking.BaggageCalculator.Classes
{
    public class FlightBaggageCalculator : IBaggageCalculator
    {
        public int CalculateBaggage(List<Passenger> passengers)
        {
            return passengers.Sum(p => 
                {
                    return p.Type == PassengerType.Discounted ? 0 : 
                        p.Type == PassengerType.LoyaltyMember ? 2 : 1;
                });
        }
    }
}