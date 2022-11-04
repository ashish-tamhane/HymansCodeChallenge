using FlightBooking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightBooking.Core.Classes
{
    public static class SummaryGenerator
    {
        private static string INDENTATION = "    ";

        public static string GenerateSummary(IEnumerable<IPassenger> passengers,
            SummaryDetails summaryDetails
            )
        {
            string VERTICAL_WHITE_SPACE = Environment.NewLine + Environment.NewLine;
            string NEW_LINE = Environment.NewLine;

            string result = GetResult(summaryDetails.flightRouteTitle);

            result += VERTICAL_WHITE_SPACE;

            result += GetSeatsTaken(summaryDetails.seatsTaken);
            result += NEW_LINE;
            result += GetGeneralSales(passengers);
            result += NEW_LINE;
            result += GetLoyaltyMemberSales(passengers);
            result += NEW_LINE;
            result += GetAirlineEmployees(passengers);

            result += VERTICAL_WHITE_SPACE;
            result += GetTotalExpectedBaggage(summaryDetails.expectedBaggageFromFlight);

            result += VERTICAL_WHITE_SPACE;

            result += GetTotalRevenueFromFlight(summaryDetails.profitFromFlight);
            result += NEW_LINE;
            result += GetTotalCostFromFlight(summaryDetails.costOfFlight);
            result += NEW_LINE;

            result += DisplayProfitOrLoss(summaryDetails.profitSurplus);

            result += VERTICAL_WHITE_SPACE;

            result += GetLoyaltyPointsGivenAway(summaryDetails.totalLoyaltyPointsAccrued) + NEW_LINE;
            result += GetTotalLoyaltyPointsRedeemed(summaryDetails.totalLoyaltyPointsRedeemed) + NEW_LINE;

            result += VERTICAL_WHITE_SPACE;

            if (FlightProceedCheck(summaryDetails.seatsTaken, summaryDetails.profitSurplus, summaryDetails.aircraftNumberOfSeats, 
                summaryDetails.flightRouteMinimumTakeOffPercentage))
                result += "THIS FLIGHT MAY PROCEED";
            else
                result += "FLIGHT MAY NOT PROCEED";

            return result;
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

        private static string GetAirlineEmployees(IEnumerable<IPassenger> passengers)
        {
            return INDENTATION + "Airline employee comps: " + passengers.Count(p => p.Type == PassengerType.AirlineEmployee);
        }

        private static string GetLoyaltyMemberSales(IEnumerable<IPassenger> passengers)
        {
            return INDENTATION + "Loyalty member sales: " + passengers.Count(p => p.Type == PassengerType.LoyaltyMember);
        }

        private static string GetGeneralSales(IEnumerable<IPassenger> passengers)
        {
            return INDENTATION + "General sales: " + passengers.Count(p => p.Type == PassengerType.General);
        }

       

        private static string DisplayProfitOrLoss(double profitSurplus)
        {
            return (profitSurplus > 0 ? "Flight generating profit of: " : "Flight losing money of: ") + profitSurplus;
        }

        private static bool FlightProceedCheck(int seatsTaken, double profitSurplus, double numberOfSeats, double minimumTakeOffPercentage)
        {
            return profitSurplus > 0 &&
                            seatsTaken < numberOfSeats &&
                            seatsTaken / numberOfSeats > minimumTakeOffPercentage;
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
