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

        [TestInitialize]
        public void TestInit()
        {
            TestMockData.SetupAirlineData(out scheduledFlight, out flightManager);
        }

        [TestMethod]
        public void TestGetSummary()
        {
            string output = SummaryGenerator.GenerateSummary(flightManager);

            Assert.AreEqual(TestMockData.ExpectedConsoleOutput.Trim(), output.Trim()) ;
        }

        [TestMethod]
        public void TestAvailablePlanes()
        {
            flightManager.AddPassenger(new Passenger() { Type = PassengerType.General });
            flightManager.AddPassenger(new Passenger() { Type = PassengerType.General });
            flightManager.AddPassenger(new Passenger() { Type = PassengerType.General });
            flightManager.AddPassenger(new Passenger() { Type = PassengerType.General });
            

            Assert.AreEqual(1, flightManager.AvailablePlanes(flightManager.GetFlightInformation().seatsTaken).Count());
        }

        [TestMethod]
        public void TestGetSummaryForRelaxedRuleSet()
        {
            flightManager.FlightValidationType = FlightValidationType.RelaxedRuleset;
            string output = SummaryGenerator.GenerateSummary(flightManager);

            Assert.AreEqual(TestMockData.ExpectedConsoleOutput.Trim(), output.Trim());
        }

        [TestMethod]
        public void TestGetFlightInformation()
        {
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
            }

        }

        [TestMethod]
        public void TestBaggageFromFlight()
        {
            int output = scheduledFlight.GetExpectedBaggageFromFlight();
            int expectedBaggageFromFlight = 13;

            Assert.AreEqual(expectedBaggageFromFlight, output);

        }

       

        

        

        [TestMethod]
        public void TestSeatsTaken()
        {
            double seatsTaken = scheduledFlight.SeatsOccupied;
            Assert.AreEqual(10, seatsTaken);
        }
    }
}
