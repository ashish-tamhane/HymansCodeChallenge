using FlightBooking.Core.Classes;
using FlightBooking.Core.Entities;
using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IFlightManager
    {
        void AddPassenger(Passenger passenger);
        void AddPassengers(IEnumerable<Passenger> passengers);
        
        int TotalLoyaltyPointsAccrued { get; set; }
        int TotalLoyaltyPointsRedeemed { get; set; }
    }
}