using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlightBooking.FlightProceedCheck.Tests
{
    [TestClass]
    public class FlightProceedCheckTests
    {
        [TestMethod]
        public void TestDefaultRuleSetWithNegativeProfitSurplus()
        {
            IFlightValidation flightValidation = new FlightDefaultRuleSetValidation()
            {
                ProfitSurplus = -10,
                SeatsOccupied = 10,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7
            };
            Assert.IsFalse(flightValidation.ValidateCondition(out string output));
            Assert.AreEqual("Profit generated failed to pass as per default ruleset.", output);
        }

        [TestMethod]
        public void TestDefaultRuleSetForLessOccupancy()
        {            
            IFlightValidation flightValidation = new FlightDefaultRuleSetValidation()
            {
                ProfitSurplus = 300,
                SeatsOccupied = 1,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7
            };
            Assert.IsFalse(flightValidation.ValidateCondition(out string output));
            Assert.AreEqual("Minimum number of seats occupied not as per required percentage.", output);
        }

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
            Assert.AreEqual("Seats occupied are more than total seats.", output);
        }

        [TestMethod]
        public void TestRelaxedRulesetNoProfit()
        {
            string output;
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                ProfitSurplus = -10,
                SeatsOccupied = 1,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7
            };
            Assert.IsFalse(flightValidation.ValidateCondition(out output));
            Assert.AreEqual("Profit generated failed to pass as per default ruleset.", output);
        }

        [TestMethod]
        public void TestRelaxedRulesetWithMorePassengers()
        {
            string output;
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                ProfitSurplus = 300,
                SeatsOccupied = 13,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7
            };
            Assert.IsFalse(flightValidation.ValidateCondition(out output));
            Assert.AreEqual("Seats occupied are more than total seats.", output);
        }

        [TestMethod]
        public void TestRelaxedRulesetWithLessPassengers()
        {
            string output;
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                ProfitSurplus = 300,
                SeatsOccupied = 1,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7
            };
            Assert.IsFalse(flightValidation.ValidateCondition(out output));
            Assert.AreEqual("Minimum number of seats occupied not as per required percentage.", output);
        }

        [TestMethod]
        public void TestRelaxedRulesetWithNoAirLineEmployees()
        {
            string output;
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                ProfitSurplus = 300,
                SeatsOccupied = 10,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7                
            };
            Assert.IsTrue(flightValidation.ValidateCondition(out output));
            Assert.AreEqual(string.Empty, output);
        }

        [TestMethod]
        public void TestRelaxedRuleset()
        {
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                ProfitSurplus = 300,
                SeatsOccupied = 10,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7,
                TotalAirLineEmployees = 10
            };
            Assert.IsTrue(flightValidation.ValidateCondition(out _));
            //Assert.AreEqual("Flight failed to pass Default ruleset.", output);
        }

        [TestMethod]
        public void TestRelaxedRulesetWithTooManyEmployees()
        {
            string output;
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                ProfitSurplus = 300,
                SeatsOccupied = 13,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7,
                TotalAirLineEmployees = 13
            };
            Assert.IsFalse(flightValidation.ValidateCondition(out output));
            Assert.AreEqual("Flight failed to pass Relaxed ruleset.", output);
        }

        [TestMethod]
        public void TestRelaxedRulesetWithLessAirlineEmployees()
        {
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                ProfitSurplus = 300,
                SeatsOccupied = 10,
                TotalSeats = 12,
                MinimumTakeOffPercentage = 0.7,
                TotalAirLineEmployees = 2
            };
            Assert.IsTrue(flightValidation.ValidateCondition(out _));
            //Assert.AreEqual("Flight failed to pass Default ruleset.", output);
        }
    }
}
