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

        [TestInitialize]
        public void TestInit()
        {
            TestMockData.SetupAirlineData(out _scheduledFlight);
        }

        [TestMethod]
        public void TestGetSummary()
        {
            string output = _scheduledFlight.GetSummary();

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
        public void TestProfitFromFlight()
        {
            double output = _scheduledFlight.GetExpectedProfitFromFlight();
            double expectedBaggageFromFlight = 800;

            Assert.AreEqual(expectedBaggageFromFlight, output);

        }

        [TestMethod]
        public void TestLoyaltyPointsFromFlight()
        {            
            Assert.AreEqual(10, _scheduledFlight.TotalLoyaltyPointsAccrued);
            Assert.AreEqual(100, _scheduledFlight.TotalLoyaltyPointsRedeemed);

        }

        [TestMethod]
        public void TestFlightCost()
        {
            double flightCost = 0;

            flightCost = _scheduledFlight.GetFlightCost();

            Assert.AreEqual(500, flightCost);
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
