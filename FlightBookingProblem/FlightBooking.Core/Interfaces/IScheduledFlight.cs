using FlightBooking.Core.Classes;
using FlightBooking.Entities.Models;
using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IScheduledFlight
    {
        FlightRoute FlightRoute { get; }
        List<Passenger> Passengers { get; }
        int SeatsOccupied { get; }

        int AirLineSeats { get; }
        double TotalSeats { get; }

        void AddPassenger(Passenger passenger);        
        
        FlightInformation GetFlightInformation();

        
    }
}