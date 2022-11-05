using FlightBooking.Core.Entities;
using FlightBooking.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.Classes
{
    public class FlightManager : IFlightManager
    {
        private IScheduledFlight scheduledFlight;
        private readonly IFlightRoute flightRoute;
        private readonly ILoyaltyPointsCalculator loyaltyPointsCalculator;
        public int TotalLoyaltyPointsAccrued { get; set; }
        public int TotalLoyaltyPointsRedeemed { get; set; }

        public FlightManager(IScheduledFlight scheduledFlight, IFlightRoute flightRoute, ILoyaltyPointsCalculator loyaltyPointsCalculator)
        {
            this.scheduledFlight = scheduledFlight;
            this.flightRoute = flightRoute;
            this.loyaltyPointsCalculator = loyaltyPointsCalculator;
        }

        public void AddPassenger(Passenger passenger)
        {
            if (loyaltyPointsCalculator.CalculateLoyaltyPoints(passenger, flightRoute, out int totalLoyaltyPointsRedeemed, out int totalLoyaltyPointsAccrued))
            {
                TotalLoyaltyPointsRedeemed += totalLoyaltyPointsRedeemed;
                TotalLoyaltyPointsAccrued += totalLoyaltyPointsAccrued;
            }

            scheduledFlight.AddPassenger(passenger);
        }

        public void AddPassengers(IEnumerable<Passenger> passengers)
        {
            passengers.ToList().ForEach(p => AddPassenger(p));
        }
    }
}