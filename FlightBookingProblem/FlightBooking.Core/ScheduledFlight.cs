using System;
using System.Linq;
using System.Collections.Generic;
using FlightBooking.Core.Interfaces;

namespace FlightBooking.Core
{
    public class ScheduledFlight : IScheduledFlight
    {
        
        
        private readonly ILoyaltyPointsCalculator loyaltyCalculator;
        private readonly IProfitCalculator profitCalculator;
        private readonly IBaggageCalculator baggageCalculator;
        private readonly IFlightRoute flightRoute;
        private IPlane Aircraft;

        

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
            Passengers = new List<IPassenger>();
        }

        
        public List<IPassenger> Passengers { get; private set; }

        public void AddPassenger(IPassenger passenger)
        {
            if (loyaltyCalculator.CalculateLoyaltyPoints(passenger, flightRoute, out int totalLoyaltyPointsRedeemed, out int totalLoyaltyPointsAccrued))
            {
                TotalLoyaltyPointsRedeemed += totalLoyaltyPointsRedeemed;
                TotalLoyaltyPointsAccrued += totalLoyaltyPointsAccrued;
            }

            Passengers.Add(passenger);
        }

        public void SetAircraftForRoute(Plane aircraft)
        {
            Aircraft = aircraft;
        }

        public int GetExpectedBaggageFromFlight()
        {
            return baggageCalculator.CalculateBaggage(Passengers);            
        }

        public double GetExpectedProfitFromFlight()
        {
            return profitCalculator.CalculateProfit(Passengers, flightRoute.BasePrice);
        }


        public double GetFlightCost()
        {
            return Passengers.Sum(p => flightRoute.BaseCost);
        }

        public int GetSeatsTaken()
        {
            return Passengers.Count();
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

            return SummaryGenerator.GenerateSummary(Passengers, flightRoute.Title, seatsTaken, profitFromFlight, costOfFlight, profitSurplus, TotalLoyaltyPointsAccrued, TotalLoyaltyPointsRedeemed, Aircraft.NumberOfSeats, flightRoute.MinimumTakeOffPercentage, GetExpectedBaggageFromFlight());
        }

        

       





    }
}
