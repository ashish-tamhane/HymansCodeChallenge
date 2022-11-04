using System;
using System.Linq;
using System.Collections.Generic;
using FlightBooking.Core.Interfaces;

namespace FlightBooking.Core.Classes
{
    public class ScheduledFlight : IScheduledFlight
    {

        private readonly ILoyaltyPointsCalculator loyaltyCalculator;
        private readonly IProfitCalculator profitCalculator;
        private readonly IBaggageCalculator baggageCalculator;
        private readonly IFlightRoute flightRoute;
        private IPlane Aircraft;
        private readonly List<IPassenger> passengers;

        public int TotalLoyaltyPointsAccrued { get; set; }
        public int TotalLoyaltyPointsRedeemed { get; set; }

        public ScheduledFlight(IFlightRoute flightRoute,
            ILoyaltyPointsCalculator loyaltyCalculator,
            IProfitCalculator profitCalculator,
            IBaggageCalculator baggageCalculator
            )
        {
            this.flightRoute = flightRoute;
            this.loyaltyCalculator = loyaltyCalculator;
            this.profitCalculator = profitCalculator;
            this.baggageCalculator = baggageCalculator;
            passengers = new List<IPassenger>();
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

        public void SetAircraftForRoute(Plane aircraft)
        {
            Aircraft = aircraft;
        }

        public int GetExpectedBaggageFromFlight()
        {
            return baggageCalculator.CalculateBaggage(passengers);
        }

        public double GetExpectedProfitFromFlight()
        {
            return profitCalculator.CalculateProfit(passengers, flightRoute.BasePrice);
        }


        public double GetFlightCost()
        {
            return passengers.Sum(p => flightRoute.BaseCost);
        }

        public int GetSeatsTaken()
        {
            return passengers.Count();
        }

        private static double GetProfitSurplus(double costOfFlight, double profitFromFlight)
        {
            return profitFromFlight - costOfFlight;
        }

        public string GetSummary()
        {
            double costOfFlight = GetFlightCost();
            double profitFromFlight = GetExpectedProfitFromFlight();
            int seatsTaken = GetSeatsTaken();
            double profitSurplus = GetProfitSurplus(costOfFlight, profitFromFlight);
            int expectedBaggageFromFlight = GetExpectedBaggageFromFlight();
            string flightRouteTitle = flightRoute.Title;
            int aircraftNumberOfSeats = Aircraft.NumberOfSeats;
            double flightRouteMinimumTakeOffPercentage = flightRoute.MinimumTakeOffPercentage;

            return SummaryGenerator.GenerateSummary(passengers, flightRouteTitle, 
                seatsTaken, profitFromFlight, costOfFlight, 
                profitSurplus, TotalLoyaltyPointsAccrued, TotalLoyaltyPointsRedeemed, aircraftNumberOfSeats,
                flightRouteMinimumTakeOffPercentage, expectedBaggageFromFlight);
        }









    }
}
