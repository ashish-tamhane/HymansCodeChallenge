using FlightBooking.Core.Classes;
using FlightBooking.Core.Classes.FinanceCalculations;
using FlightBooking.Entities.Models;
using FlightBooking.Manager.Classes;

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
            
            FlightInformation flightInformation = scheduledFlight.GetFlightInformation();
            FlightFinance flightFinance = new FlightFinance(scheduledFlight, scheduledFlight.FlightRoute, new ProfitCalculator());

            flightInformation.costOfFlight = flightFinance.CostOfFlight();
            flightInformation.profitFromFlight = flightFinance.ProfitFromFlight();
            flightInformation.profitSurplus = flightFinance.ProfitSurplus();
            flightInformation.totalLoyaltyPointsAccrued = flightManager.TotalLoyaltyPointsAccrued;
            flightInformation.totalLoyaltyPointsRedeemed = flightManager.TotalLoyaltyPointsRedeemed;

            string output = SummaryGenerator.GenerateSummary(scheduledFlight.Passengers, flightInformation, flightManager);

            Assert.AreEqual(TestMockData.ExpectedConsoleOutput, output);
        }

        [TestMethod]
        public void TestGetFlightInformation()
        {

            FlightInformation flightInformation = scheduledFlight.GetFlightInformation();
            FlightFinance flightFinance = new FlightFinance(scheduledFlight, scheduledFlight.FlightRoute, new ProfitCalculator());

            flightInformation.costOfFlight = flightFinance.CostOfFlight();
            flightInformation.profitFromFlight = flightFinance.ProfitFromFlight();
            flightInformation.profitSurplus = flightFinance.ProfitSurplus();
            flightInformation.totalLoyaltyPointsAccrued = flightManager.TotalLoyaltyPointsAccrued;
            flightInformation.totalLoyaltyPointsRedeemed = flightManager.TotalLoyaltyPointsRedeemed;

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
            

            Assert.AreEqual(10, flightInformation.seatsTaken);
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
            double seatsTaken = 0;

            seatsTaken = scheduledFlight.SeatsOccupied;

            Assert.AreEqual(10, seatsTaken);
        }
    }
}
