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
            int expectedBaggageFromFlight = 3;

            Assert.AreEqual(expectedBaggageFromFlight, output);

        }
    }
}
