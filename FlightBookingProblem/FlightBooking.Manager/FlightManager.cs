using FlightBooking.Core.Classes;
using FlightBooking.Core.Interfaces;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using FlightBooking.Entities.Models;
using FlightBooking.FlightProceedCheck;
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

        public FlightValidationType FlightValidationType { get; set; }

        public FlightManager(IScheduledFlight scheduledFlight, 
            FlightRoute flightRoute, 
            ILoyaltyPointsCalculator loyaltyPointsCalculator,
            IFlightFinance flightFinance,            
            FlightValidationType flightValidationType
            )
        {
            this.scheduledFlight = scheduledFlight;
            this.flightRoute = flightRoute;
            this.loyaltyPointsCalculator = loyaltyPointsCalculator;
            this.flightFinance = flightFinance;            
            FlightValidationType = flightValidationType;
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

        public bool FlightProceedCheck(out string validation)
        {            
            IFlightValidation flightValidation = null;

            switch (FlightValidationType)
            {
                case FlightValidationType.DefaultRuleset:
                    flightValidation = new FlightDefaultRuleSetValidation()
                    {
                        ProfitSurplus = flightFinance.ProfitSurplus(),
                        SeatsOccupied = scheduledFlight.SeatsOccupied,
                        TotalSeats = scheduledFlight.TotalSeats,
                        MinimumTakeOffPercentage = flightRoute.MinimumTakeOffPercentage
                    };
                    break;
                case FlightValidationType.RelaxedRuleset:
                    flightValidation = new FlightRelaxedRuleSetValidation()
                    {
                        profitSurplus = flightFinance.ProfitSurplus(),
                        seatsOccupied = scheduledFlight.SeatsOccupied,
                        totalSeats = scheduledFlight.TotalSeats,
                        minimumTakeOffPercentage = flightRoute.MinimumTakeOffPercentage,
                        totalAirLineEmployees = scheduledFlight.AirLineSeats
                    };
                    break;                
                default:
                    break;
            }

            return flightValidation.ValidateCondition(out validation);
        }

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

        public bool ArePassengersMoreThanSeats()
        {
            return scheduledFlight.SeatsOccupied > scheduledFlight.TotalSeats;
        }

        public IEnumerable<Plane> AvailablePlanes(int passengerCount)
        {
            return PlanesList.Planes.Where(p => p.NumberOfSeats > passengerCount);
        }
    }
}