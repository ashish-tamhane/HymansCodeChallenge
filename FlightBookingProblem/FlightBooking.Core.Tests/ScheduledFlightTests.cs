using FlightBooking.Core.Classes;
using FlightBooking.Core.Classes.FinanceCalculations;
using FlightBooking.Entities.Enumerations;
using FlightBooking.Entities.Models;
using FlightBooking.FlightProceedCheck;
using FlightBooking.Manager.Classes;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class ScheduledFlightTests
    {        
        private static ScheduledFlight scheduledFlight;
        private FlightManager flightManager;

        [TestMethod]
        public void TestTooManyPassengers()
        {
            TestMockData.SetupAirlineDataForTooManyPassengers(out scheduledFlight, out flightManager);
            string output = SummaryGenerator.GenerateSummary(flightManager);

            Assert.AreEqual(TestMockData.ExpectedConsoleOutputForTooManyPassengers.Trim(), output.Trim());
        }

        [TestMethod]
        public void TestGetSummaryForRelaxedRuleSetAndDefaultPassengers()
        {
            TestMockData.SetupAirlineData(out scheduledFlight, out flightManager);
            flightManager.FlightValidationType = FlightValidationType.RelaxedRuleset;
            string output = SummaryGenerator.GenerateSummary(flightManager);

            Assert.AreEqual(TestMockData.ExpectedConsoleOutput.Trim(), output.Trim());
        }

        [TestMethod]
        public void TestGetSummaryWithDefaultRuleSetAndMoreAirlineEmployees()
        {
            TestMockData.SetupAirlineDataForRelaxedRuleSet(out scheduledFlight, out flightManager);            
            string output = SummaryGenerator.GenerateSummary(flightManager);

            Assert.AreEqual(TestMockData.ExpectedConsoleOutputForDefaultRuleSetWithMoreAirlineEmployees.Trim(), output.Trim());
        }

        [TestMethod]
        public void TestGetSummaryWithRelaxedRuleSetAndMoreAirlineEmployees()
        {
            TestMockData.SetupAirlineDataForRelaxedRuleSet(out scheduledFlight, out flightManager);
            flightManager.FlightValidationType = FlightValidationType.RelaxedRuleset;
            string output = SummaryGenerator.GenerateSummary(flightManager);

            Assert.AreEqual(TestMockData.ExpectedConsoleOutputForRelaxedRuleSet.Trim(), output.Trim());
        }
        
        

        [TestMethod]
        public void TestGetFlightInformation()
        {
            TestMockData.SetupAirlineData(out scheduledFlight, out flightManager);
            FlightInformation flightInformation = flightManager.GetFlightInformation();
            
            Assert.AreEqual(12, flightInformation.aircraftNumberOfSeats);
            Assert.AreEqual(500, flightInformation.costOfFlight);
            Assert.AreEqual(13, flightInformation.expectedBaggageFromFlight);
            Assert.AreEqual(0.7, flightInformation.flightRouteMinimumTakeOffPercentage);
            Assert.AreEqual("London to Paris", flightInformation.flightRouteTitle);
            Assert.AreEqual(800, flightInformation.profitFromFlight);
            Assert.AreEqual(300, flightInformation.profitSurplus);
            Assert.AreEqual(10, flightInformation.seatsTaken);
            Assert.AreEqual(10, flightInformation.totalLoyaltyPointsAccrued);
            Assert.AreEqual(100, flightInformation.totalLoyaltyPointsRedeemed);            
            Assert.AreEqual(1, flightInformation.airlineSeats);
            Assert.IsFalse(flightManager.ArePassengersMoreThanSeats());

            foreach (var item in flightManager.GetPassengers())
            {                
                Assert.IsTrue(TestMockData.GetPassengers().Any(p => p.Type == item.Type && p.Name == item.Name));
                Assert.IsTrue(TestMockData.GetPassengers().Any(p => p.IsUsingLoyaltyPoints == item.IsUsingLoyaltyPoints && p.Name == item.Name));
                Assert.IsTrue(TestMockData.GetPassengers().Any(p => p.Age == item.Age && p.Name == item.Name));
                Assert.IsTrue(TestMockData.GetPassengers().Any(p => p.AllowedBags == item.AllowedBags && p.Name == item.Name));
            }

        }

        

        [TestMethod]
        public void TestSeatsTaken()
        {
            TestMockData.SetupAirlineData(out scheduledFlight, out flightManager);
            double seatsTaken = scheduledFlight.SeatsOccupied;
            Assert.AreEqual(10, seatsTaken);
        }
    }
}
