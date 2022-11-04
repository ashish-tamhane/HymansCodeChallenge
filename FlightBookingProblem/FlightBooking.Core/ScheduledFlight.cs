using System;
using System.Linq;
using System.Collections.Generic;
using FlightBooking.Core.Interfaces;

namespace FlightBooking.Core
{
    public class ScheduledFlight : IScheduledFlight
    {
        private readonly string VERTICAL_WHITE_SPACE = Environment.NewLine + Environment.NewLine;
        private readonly string NEW_LINE = Environment.NewLine;        
        private const string INDENTATION = "    ";

        public int TotalLoyaltyPointsAccrued { get; set; }
        public int TotalLoyaltyPointsRedeemed { get; set; }

        public ScheduledFlight(IFlightRoute flightRoute)
        {
            FlightRoute = flightRoute;
            Passengers = new List<IPassenger>();
        }

        public IFlightRoute FlightRoute { get; private set; }
        public IPlane Aircraft { get; private set; }
        public List<IPassenger> Passengers { get; private set; }

        public void AddPassenger(IPassenger passenger, ILoyaltyPointsCalculator loyaltyCalculator)
        {
            int totalLoyaltyPointsAccrued;
            int totalLoyaltyPointsRedeemed;
            
            if (loyaltyCalculator.CalculateLoyaltyPoints(passenger, FlightRoute, out totalLoyaltyPointsRedeemed, out totalLoyaltyPointsAccrued))
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
            return Passengers.Sum(p => { return p.Type == PassengerType.LoyaltyMember ? 2 : 1; });
        }

        public double GetExpectedProfitFromFlight()
        {
            return Passengers.Sum(p =>
                        p.Type == PassengerType.AirlineEmployee ? 0
                                                    : (p.Type == PassengerType.General ? FlightRoute.BasePrice
                                                                : (p.IsUsingLoyaltyPoints ? 0 : FlightRoute.BasePrice)));
        }


        public double GetFlightCost()
        {
            return Passengers.Sum(p => FlightRoute.BaseCost);
        }

        public int GetSeatsTaken()
        {
            return Passengers.Count();
        }

        public string GetSummary()
        {
            double costOfFlight = GetFlightCost();
            double profitFromFlight = GetExpectedProfitFromFlight();
            int seatsTaken = GetSeatsTaken();

            string result = "Flight summary for " + FlightRoute.Title;

            result += VERTICAL_WHITE_SPACE;

            result += "Total passengers: " + seatsTaken;
            result += NEW_LINE;
            result += INDENTATION + "General sales: " + Passengers.Count(p => p.Type == PassengerType.General);
            result += NEW_LINE;
            result += INDENTATION + "Loyalty member sales: " + Passengers.Count(p => p.Type == PassengerType.LoyaltyMember);
            result += NEW_LINE;
            result += INDENTATION + "Airline employee comps: " + Passengers.Count(p => p.Type == PassengerType.AirlineEmployee);

            result += VERTICAL_WHITE_SPACE;
            result += "Total expected baggage: " + GetExpectedBaggageFromFlight();

            result += VERTICAL_WHITE_SPACE;

            result += "Total revenue from flight: " + profitFromFlight;
            result += NEW_LINE;
            result += "Total costs from flight: " + costOfFlight;
            result += NEW_LINE;

            double profitSurplus = profitFromFlight - costOfFlight;

            result += (profitSurplus > 0 ? "Flight generating profit of: " : "Flight losing money of: ") + profitSurplus;

            result += VERTICAL_WHITE_SPACE;

            result += "Total loyalty points given away: " + TotalLoyaltyPointsAccrued + NEW_LINE;
            result += "Total loyalty points redeemed: " + TotalLoyaltyPointsRedeemed + NEW_LINE;

            result += VERTICAL_WHITE_SPACE;

            if (profitSurplus > 0 &&
                seatsTaken < Aircraft.NumberOfSeats &&
                seatsTaken / (double)Aircraft.NumberOfSeats > FlightRoute.MinimumTakeOffPercentage)
                result += "THIS FLIGHT MAY PROCEED";
            else
                result += "FLIGHT MAY NOT PROCEED";

            return result;
        }


    }
}
