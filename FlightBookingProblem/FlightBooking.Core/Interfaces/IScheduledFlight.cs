using FlightBooking.Core.Classes;
using System.Collections.Generic;
using FlightBooking.Core.Entities;

namespace FlightBooking.Core.Interfaces
{
    public interface IScheduledFlight
    {
        IFlightRoute FlightRoute { get; }
        List<Passenger> Passengers { get; }
        int SeatsOccupied { get; }
        double TotalSeats { get; }

        void AddPassenger(Passenger passenger);        
        
        FlightInformation GetFlightInformation();

        
    }
}