using FlightBooking.Core.Classes;
using FlightBooking.Core.Classes.FinanceCalculations;
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
