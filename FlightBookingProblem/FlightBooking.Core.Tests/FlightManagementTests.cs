using FlightBooking.Core.Classes;
using FlightBooking.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class FlightManagementTests
    {
        private ScheduledFlight _scheduledFlight;
        private FlightManager _flightManager;

        [TestInitialize]
        public void TestInit()
        {
            TestMockData.SetupAirlineData(out _scheduledFlight, out _flightManager);
        }

        [TestMethod]
        public void TestLoyaltyPointsFromFlight()
        {                        
            Assert.AreEqual(10, _flightManager.TotalLoyaltyPointsAccrued);
            Assert.AreEqual(100, _flightManager.TotalLoyaltyPointsRedeemed);
        }
    }
}
