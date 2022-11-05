using System;
using System.Linq;
using System.Collections.Generic;
using FlightBooking.Core.Interfaces;

namespace FlightBooking.Core.Classes
{
    public class ScheduledFlight : IScheduledFlight
    {
        //Loyalty points calculation should be outside ScheduledFlight
        private readonly ILoyaltyPointsCalculator loyaltyCalculator;        

        private readonly IPlane Aircraft;
        private readonly List<IPassenger> passengers;
        private readonly IBaggageCalculator baggageCalculator;
        private readonly IFlightRoute flightRoute;

        public int TotalLoyaltyPointsAccrued { get; set; }
        public int TotalLoyaltyPointsRedeemed { get; set; }

        public IFlightRoute FlightRoute => flightRoute;

        public List<IPassenger> Passengers => passengers;



        public ScheduledFlight(IFlightRoute flightRoute,
            ILoyaltyPointsCalculator loyaltyCalculator,            
            IBaggageCalculator baggageCalculator,
            IPlane plane
            )
        {
            this.flightRoute = flightRoute;
            this.loyaltyCalculator = loyaltyCalculator;            
            this.baggageCalculator = baggageCalculator;
            passengers = new List<IPassenger>();
            Aircraft = plane;
        }

        public void AddPassenger(IPassenger passenger)
        {
            if (loyaltyCalculator.CalculateLoyaltyPoints(passenger, flightRoute, out int totalLoyaltyPointsRedeemed, out int totalLoyaltyPointsAccrued))
            {
                TotalLoyaltyPointsRedeemed += totalLoyaltyPointsRedeemed;
                TotalLoyaltyPointsAccrued += totalLoyaltyPointsAccrued;
            }

            passengers.Add(passenger);
        }

        public void AddPassengers(IEnumerable<IPassenger> passengers)
        {
            passengers.ToList().ForEach(p => AddPassenger(p));
        }


        public int GetExpectedBaggageFromFlight()
        {
            return baggageCalculator.CalculateBaggage(passengers);
        }

        public int GetSeatsTaken()
        {
            return passengers.Count();
        }

        public FlightInformation GetFlightInformation()
        {
            double flightRouteMinimumTakeOffPercentage = flightRoute.MinimumTakeOffPercentage;

            string flightRouteTitle = flightRoute.Title;
            int aircraftNumberOfSeats = Aircraft.NumberOfSeats;
            int seatsTaken = GetSeatsTaken();
            int expectedBaggageFromFlight = GetExpectedBaggageFromFlight();

            return new FlightInformation()
            {
                seatsTaken = seatsTaken,
                expectedBaggageFromFlight = expectedBaggageFromFlight,
                flightRouteTitle = flightRouteTitle,
                aircraftNumberOfSeats = aircraftNumberOfSeats,
                flightRouteMinimumTakeOffPercentage = flightRouteMinimumTakeOffPercentage,
                totalLoyaltyPointsAccrued = TotalLoyaltyPointsAccrued,
                totalLoyaltyPointsRedeemed = TotalLoyaltyPointsRedeemed
            };
        }
    }
}
