using FlightBooking.Entities.Models;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using System.Collections.Generic;
using FlightBooking.FlightProceedCheck;

namespace FlightBooking.Manager.Interfaces
{
    public interface IFlightManager
    {
        void AddPassenger(Passenger passenger);
        void AddPassengers(IEnumerable<Passenger> passengers);

        int TotalLoyaltyPointsAccrued { get; set; }
        int TotalLoyaltyPointsRedeemed { get; set; }

        bool FlightProceedCheck(out string validation);

        bool ArePassengersMoreThanSeats();

        FlightValidationType FlightValidationType { get; set; }
        IEnumerable<Plane> AvailablePlanes(int passengerCount);

        IEnumerable<Passenger> GetPassengers();

        FlightInformation GetFlightInformation();
    }
}