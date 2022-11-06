﻿namespace FlightBooking.Entities.Models
{
    public struct FlightInformation
    {
        public double costOfFlight { get; set; }
        public double profitFromFlight { get; set; }
        public int seatsTaken { get; set; }
        public double profitSurplus { get; set; }
        public int expectedBaggageFromFlight { get; set; }
        public string flightRouteTitle { get; set; }
        public int aircraftNumberOfSeats { get; set; }
        public double flightRouteMinimumTakeOffPercentage { get; set; }
        public int totalLoyaltyPointsAccrued { get; set; }
        public int totalLoyaltyPointsRedeemed { get; set; }

        public int airlineSeats { get; set; }
    }
}
