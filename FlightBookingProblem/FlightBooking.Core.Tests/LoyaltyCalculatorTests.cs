using FlightBooking.Core.Classes;
using FlightBooking.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class LoyaltyCalculatorTests
    {
        [TestMethod]
        public void TestExampleLoyaltyCalculator()
        {
            int totalLoyaltyPointsRedeemed = 0;
            int totalLoyaltyPointsAccrued = 0;
            
            ILoyaltyPointsCalculator loyaltyPointsCalculator = new LoyaltyPointsCalculator();
            IFlightRoute flightRoute = new FlightRoute("London", "Paris")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.7
            };

            var passengers = TestMockData.GetPassengers();

            foreach (IPassenger passenger in passengers)
            {
                if (loyaltyPointsCalculator.CalculateLoyaltyPoints(passenger, flightRoute, out int loyaltyPointsRedeemed, out int loyaltyPointsAccrued))
                {
                    totalLoyaltyPointsRedeemed += loyaltyPointsRedeemed;
                    totalLoyaltyPointsAccrued += loyaltyPointsAccrued;
                }
            }

            Assert.AreEqual(100, totalLoyaltyPointsRedeemed);
            Assert.AreEqual(10, totalLoyaltyPointsAccrued);
        }
    }
}
