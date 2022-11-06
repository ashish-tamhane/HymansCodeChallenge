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
            string output;
            IFlightValidation flightValidation = new FlightDefaultRuleSetValidation() 
                    { 
                        profitSurplus = 300, seatsOccupied = 10, totalSeats = 12, minimumTakeOffPercentage = 0.7 
                    };
            Assert.IsTrue(flightValidation.ValidateCondition(out output));
            Assert.AreEqual(string.Empty, output);
        }

        [TestMethod]
        public void TestDefaultRuleSetForFalse()
        {
            string output;
            IFlightValidation flightValidation = new FlightDefaultRuleSetValidation()
                    { 
                        profitSurplus = 300, seatsOccupied = 13, totalSeats = 12, minimumTakeOffPercentage = 0.7 
                    };
            Assert.IsFalse(flightValidation.ValidateCondition(out output));
            Assert.AreEqual("Flight failed to pass Default ruleset.", output);
        }

        [TestMethod]
        public void TestRelaxedRuleset()
        {
            string output;
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                profitSurplus = 300,
                seatsOccupied = 10,
                totalSeats = 12,
                minimumTakeOffPercentage = 0.7,
                totalAirLineEmployees = 10
            };
            Assert.IsTrue(flightValidation.ValidateCondition(out output));
            //Assert.AreEqual("Flight failed to pass Default ruleset.", output);
        }

        [TestMethod]
        public void TestRelaxedRulesetWithLessAirlineEmployees()
        {
            string output;
            IFlightValidation flightValidation = new FlightRelaxedRuleSetValidation()
            {
                profitSurplus = 300,
                seatsOccupied = 10,
                totalSeats = 12,
                minimumTakeOffPercentage = 0.7,
                totalAirLineEmployees = 2
            };
            Assert.IsTrue(flightValidation.ValidateCondition(out output));
            //Assert.AreEqual("Flight failed to pass Default ruleset.", output);
        }
    }
}
