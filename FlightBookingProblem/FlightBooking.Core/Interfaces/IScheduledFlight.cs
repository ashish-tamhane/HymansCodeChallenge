using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IScheduledFlight
    {
        IPlane Aircraft { get; }
        IFlightRoute FlightRoute { get; }
        List<IPassenger> Passengers { get; }

        void AddPassenger(IPassenger passenger, ILoyaltyPointsCalculator loyaltyPointsCalculator);
        string GetSummary();
        void SetAircraftForRoute(Plane aircraft);
    }
}