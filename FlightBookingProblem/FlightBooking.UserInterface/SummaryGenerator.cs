using FlightBooking.Core.Entities;
using FlightBooking.Core.Enumerations;
using FlightBooking.Manager.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.Classes
{
    public static class SummaryGenerator
    {
        private static string INDENTATION = "    ";

        public static string GenerateSummary(IEnumerable<Passenger> passengers,
            FlightInformation summaryDetails,
            FlightManager flightManager
            )
        {            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetResult(summaryDetails.flightRouteTitle));
            sb.AppendLine();
            sb.AppendLine(GetSeatsTaken(summaryDetails.seatsTaken));            
            sb.AppendLine(GetGeneralSales(passengers));            
            sb.AppendLine(GetLoyaltyMemberSales(passengers));            
            sb.AppendLine(GetAirlineEmployees(passengers));            
            sb.AppendLine();
            sb.AppendLine(GetTotalExpectedBaggage(summaryDetails.expectedBaggageFromFlight));            
            sb.AppendLine();            
            sb.AppendLine(GetTotalRevenueFromFlight(summaryDetails.profitFromFlight));            
            sb.AppendLine(GetTotalCostFromFlight(summaryDetails.costOfFlight));                      
            sb.AppendLine(DisplayProfitOrLoss(summaryDetails.profitSurplus));            
            sb.AppendLine();            
            sb.AppendLine(GetLoyaltyPointsGivenAway(summaryDetails.totalLoyaltyPointsAccrued));
            sb.AppendLine(GetTotalLoyaltyPointsRedeemed(summaryDetails.totalLoyaltyPointsRedeemed));            
            sb.AppendLine();            
            sb.AppendLine();

            if (flightManager.FlightProceedCheck())
                sb.Append("THIS FLIGHT MAY PROCEED");
            else
                sb.Append("FLIGHT MAY NOT PROCEED");
            
            return sb.ToString();
        }
        private static string GetTotalExpectedBaggage(int expectedBaggageFromFlight)
        {
            return "Total expected baggage: " + expectedBaggageFromFlight;
        }

        private static string GetTotalLoyaltyPointsRedeemed(int totalLoyaltyPointsRedeemed)
        {
            return "Total loyalty points redeemed: " + totalLoyaltyPointsRedeemed;
        }

        private static string GetLoyaltyPointsGivenAway(int totalLoyaltyPointsAccrued)
        {
            return "Total loyalty points given away: " + totalLoyaltyPointsAccrued;
        }

        private static string GetTotalCostFromFlight(double costOfFlight)
        {
            return "Total costs from flight: " + costOfFlight;
        }

        private static string GetTotalRevenueFromFlight(double profitFromFlight)
        {
            return "Total revenue from flight: " + profitFromFlight;
        }

        private static string GetAirlineEmployees(IEnumerable<Passenger> passengers)
        {
            return INDENTATION + "Airline employee comps: " + passengers.Count(p => p.Type == PassengerType.AirlineEmployee);
        }

        private static string GetLoyaltyMemberSales(IEnumerable<Passenger> passengers)
        {
            return INDENTATION + "Loyalty member sales: " + passengers.Count(p => p.Type == PassengerType.LoyaltyMember);
        }

        private static string GetGeneralSales(IEnumerable<Passenger> passengers)
        {
            return INDENTATION + "General sales: " + passengers.Count(p => p.Type == PassengerType.General);
        }

       

        private static string DisplayProfitOrLoss(double profitSurplus)
        {
            return (profitSurplus > 0 ? "Flight generating profit of: " : "Flight losing money of: ") + profitSurplus;
        }


        private static string GetResult(string flightRouteTitle)
        {
            return "Flight summary for " + flightRouteTitle;
        }

        private static string GetSeatsTaken(int seatsTaken)
        {
            return "Total passengers: " + seatsTaken;
        }
    }
}
