
using FlightBooking.Entities.Models;
using FlightBooking.Entities.Enumerations;
using FlightBooking.Manager.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightBooking.Manager.Interfaces;

namespace FlightBooking.Core.Classes
{
    public static class SummaryGenerator
    {
        private static readonly string INDENTATION = "    ";

        public static string GenerateSummary(
            IFlightManager flightManager
            )
        {
            FlightInformation flightInformation = flightManager.GetFlightInformation();
            IEnumerable<Passenger> passengers = flightManager.GetPassengers();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetResult(flightInformation.flightRouteTitle));
            sb.AppendLine();
            sb.AppendLine(GetSeatsTaken(flightInformation.seatsTaken));            
            sb.AppendLine(GetGeneralSales(passengers));            
            sb.AppendLine(GetLoyaltyMemberSales(passengers));
            sb.AppendLine(GetDiscountedSales(passengers));
            sb.AppendLine(GetAirlineEmployees(passengers));            
            sb.AppendLine();
            sb.AppendLine(GetTotalExpectedBaggage(flightInformation.expectedBaggageFromFlight));            
            sb.AppendLine();            
            sb.AppendLine(GetTotalRevenueFromFlight(flightInformation.profitFromFlight));            
            sb.AppendLine(GetTotalCostFromFlight(flightInformation.costOfFlight));                      
            sb.AppendLine(DisplayProfitOrLoss(flightInformation.profitSurplus));            
            sb.AppendLine();            
            sb.AppendLine(GetLoyaltyPointsGivenAway(flightInformation.totalLoyaltyPointsAccrued));
            sb.AppendLine(GetTotalLoyaltyPointsRedeemed(flightInformation.totalLoyaltyPointsRedeemed));            
            sb.AppendLine();            
            sb.AppendLine();

            if (flightManager.FlightProceedCheck(out string validationMessage))
            {
                sb.Append("THIS FLIGHT MAY PROCEED");
            }
            else
            {
                sb.AppendLine("FLIGHT MAY NOT PROCEED");
                if (flightManager.ArePassengersMoreThanSeats())
                {
                    var availablePlanes = flightManager.AvailablePlanes(flightManager.GetPassengers().Count());

                    if (availablePlanes.Any())
                    {
                        sb.AppendLine("Other more suitable aircraft are:");
                        availablePlanes.ToList().ForEach(p => sb.AppendLine(p.Name));
                    }                    
                }                
            }
            
            return sb.ToString();
        }
        private static string GetTotalExpectedBaggage(int expectedBaggageFromFlight) 
            => "Total expected baggage: " + expectedBaggageFromFlight;

        private static string GetTotalLoyaltyPointsRedeemed(int totalLoyaltyPointsRedeemed) => "Total loyalty points redeemed: " + totalLoyaltyPointsRedeemed;

        private static string GetLoyaltyPointsGivenAway(int totalLoyaltyPointsAccrued) => "Total loyalty points given away: " + totalLoyaltyPointsAccrued;

        private static string GetTotalCostFromFlight(double costOfFlight) => "Total costs from flight: " + costOfFlight;

        private static string GetTotalRevenueFromFlight(double profitFromFlight) => "Total revenue from flight: " + profitFromFlight;

        private static string GetAirlineEmployees(IEnumerable<Passenger> passengers) => INDENTATION + "Airline employee comps: " + passengers.Count(p => p.Type == PassengerType.AirlineEmployee);

        private static string GetLoyaltyMemberSales(IEnumerable<Passenger> passengers) => INDENTATION + "Loyalty member sales: " + passengers.Count(p => p.Type == PassengerType.LoyaltyMember);

        private static string GetGeneralSales(IEnumerable<Passenger> passengers) => INDENTATION + "General sales: " + passengers.Count(p => p.Type == PassengerType.General);

        private static string GetDiscountedSales(IEnumerable<Passenger> passengers) => INDENTATION + "Discounted member sales: " + passengers.Count(p => p.Type == PassengerType.Discounted);

        private static string DisplayProfitOrLoss(double profitSurplus) => (profitSurplus > 0 ? "Flight generating profit of: " : "Flight losing money of: ") + profitSurplus;


        private static string GetResult(string flightRouteTitle) => "Flight summary for " + flightRouteTitle;

        private static string GetSeatsTaken(int seatsTaken) => "Total passengers: " + seatsTaken;
    }
}
