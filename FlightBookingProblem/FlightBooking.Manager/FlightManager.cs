using FlightBooking.Core.Classes;
using FlightBooking.Core.Interfaces;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using FlightBooking.Entities.Models;
using FlightBooking.Manager.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Manager.Classes
{
    public class FlightManager : IFlightManager
    {
        private readonly IScheduledFlight scheduledFlight;
        private readonly FlightRoute flightRoute;
        private readonly ILoyaltyPointsCalculator loyaltyPointsCalculator;
        private readonly IFlightFinance flightFinance;

        public int TotalLoyaltyPointsAccrued { get; set; }
        public int TotalLoyaltyPointsRedeemed { get; set; }

        public IFlightFinance FlightFinance => flightFinance;

        public FlightManager(IScheduledFlight scheduledFlight, 
            FlightRoute flightRoute, 
            ILoyaltyPointsCalculator loyaltyPointsCalculator,
            IFlightFinance flightFinance)
        {
            this.scheduledFlight = scheduledFlight;
            this.flightRoute = flightRoute;
            this.loyaltyPointsCalculator = loyaltyPointsCalculator;
            this.flightFinance = flightFinance;
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
            => passengers.ToList().ForEach(p => AddPassenger(p));

        public bool FlightProceedCheck() 
            => flightFinance.ProfitSurplus() > 0 &&
                            scheduledFlight.SeatsOccupied < scheduledFlight.TotalSeats &&
                            scheduledFlight.SeatsOccupied / scheduledFlight.TotalSeats > flightRoute.MinimumTakeOffPercentage;

        public IEnumerable<Passenger> GetPassengers()
        {
            return scheduledFlight.Passengers;
        }

        public FlightInformation GetFlightInformation()
        {
            var flightInformation = scheduledFlight.GetFlightInformation();

            flightInformation.costOfFlight = flightFinance.CostOfFlight();
            flightInformation.profitFromFlight = flightFinance.ProfitFromFlight();
            flightInformation.profitSurplus = flightFinance.ProfitSurplus();
            
            flightInformation.totalLoyaltyPointsAccrued = TotalLoyaltyPointsAccrued;
            flightInformation.totalLoyaltyPointsRedeemed = TotalLoyaltyPointsRedeemed;

            return flightInformation;
        }
    }
}