using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IScheduledFlight
    {
        Plane Aircraft { get; }
        FlightRoute FlightRoute { get; }
        List<Passenger> Passengers { get; }

        void AddPassenger(Passenger passenger);
        string GetSummary();
        void SetAircraftForRoute(Plane aircraft);
    }
}