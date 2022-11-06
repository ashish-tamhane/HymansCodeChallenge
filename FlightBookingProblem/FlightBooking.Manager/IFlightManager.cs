using FlightBooking.Entities.Models;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using System.Collections.Generic;

namespace FlightBooking.Manager.Interfaces
{
    public interface IFlightManager
    {
        void AddPassenger(Passenger passenger);
        void AddPassengers(IEnumerable<Passenger> passengers);

        int TotalLoyaltyPointsAccrued { get; set; }
        int TotalLoyaltyPointsRedeemed { get; set; }

        IFlightFinance FlightFinance { get;}

        bool FlightProceedCheck();

        bool ArePassengersMoreThanSeats();

        IEnumerable<Plane> AvailablePlanes(int passengerCount);

        IEnumerable<Passenger> GetPassengers();

        FlightInformation GetFlightInformation();
    }
}