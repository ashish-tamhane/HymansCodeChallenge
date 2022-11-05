using FlightBooking.Core.Classes;
using FlightBooking.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class ScheduledFlightTests
    {
        

        private static ScheduledFlight _scheduledFlight;
        private FlightManager _flightManager;

        [TestInitialize]
        public void TestInit()
        {
            TestMockData.SetupAirlineData(out _scheduledFlight, out _flightManager);
        }

        [TestMethod]
        public void TestGetSummary()
        {
            
            FlightInformation flightInformation = _scheduledFlight.GetFlightInformation();
            FlightFinance flightFinance = new FlightFinance(_scheduledFlight, _scheduledFlight.FlightRoute, new ProfitCalculator());

            flightInformation.costOfFlight = flightFinance.CostOfFlight();
            flightInformation.profitFromFlight = flightFinance.ProfitFromFlight();
            flightInformation.profitSurplus = flightFinance.ProfitSurplus();
            flightInformation.totalLoyaltyPointsAccrued = _flightManager.TotalLoyaltyPointsAccrued;
            flightInformation.totalLoyaltyPointsRedeemed = _flightManager.TotalLoyaltyPointsRedeemed;

            string output = SummaryGenerator.GenerateSummary(_scheduledFlight.Passengers, flightInformation);

            Assert.AreEqual(TestMockData.ExpectedConsoleOutput, output);
        }

        [TestMethod]
        public void TestBaggageFromFlight()
        {
            int output = _scheduledFlight.GetExpectedBaggageFromFlight();
            int expectedBaggageFromFlight = 13;

            Assert.AreEqual(expectedBaggageFromFlight, output);

        }

       

        

        

        [TestMethod]
        public void TestSeatsTaken()
        {
            double seatsTaken = 0;

            seatsTaken = _scheduledFlight.GetSeatsTaken();

            Assert.AreEqual(10, seatsTaken);
        }
    }
}
