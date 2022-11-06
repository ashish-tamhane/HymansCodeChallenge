using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlightBooking.FlightProceedCheck.Tests
{
    [TestClass]
    public class FlightProceedCheckTests
    {
        [TestMethod]
        public void TestDefaultRuleSet()
        {
            IFlightValidation flightValidation = new FlightDefaultRuleSetValidation()
            {
                ProfitSurplus = 300,
                SeatsOccupied = 10,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7
            };
            Assert.IsTrue(flightValidation.ValidateCondition(out string output));
            Assert.AreEqual(string.Empty, output);
        }

        [TestMethod]
        public void TestDefaultRuleSetForFalse()
        {
            IFlightValidation flightValidation = new FlightDefaultRuleSetValidation()
            {
                ProfitSurplus = 300,
                SeatsOccupied = 13,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7
            };
            Assert.IsFalse(flightValidation.ValidateCondition(out string output));
            Assert.AreEqual("Profit generated failed to pass as per default ruleset.", output);
        }

        [TestMethod]
        public void TestRelaxedRuleset()
        {
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                profitSurplus = 300,
                seatsOccupied = 10,
                totalSeats = 12,
                minimumTakeOffPercentage = 0.7,
                totalAirLineEmployees = 10
            };
            Assert.IsTrue(flightValidation.ValidateCondition(out _));
            //Assert.AreEqual("Flight failed to pass Default ruleset.", output);
        }

        [TestMethod]
        public void TestRelaxedRulesetWithLessAirlineEmployees()
        {
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                profitSurplus = 300,
                seatsOccupied = 10,
                totalSeats = 12,
                minimumTakeOffPercentage = 0.7,
                totalAirLineEmployees = 2
            };
            Assert.IsTrue(flightValidation.ValidateCondition(out _));
            //Assert.AreEqual("Flight failed to pass Default ruleset.", output);
        }
    }
}
