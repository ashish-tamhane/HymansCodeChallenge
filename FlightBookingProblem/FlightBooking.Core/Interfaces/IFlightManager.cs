using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IFlightManager
    {
        void AddPassenger(IPassenger passenger);
        void AddPassengers(IEnumerable<IPassenger> passengers);
        
        int TotalLoyaltyPointsAccrued { get; set; }
        int TotalLoyaltyPointsRedeemed { get; set; }
    }
}