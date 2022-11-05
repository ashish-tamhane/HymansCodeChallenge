using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightBooking.Core.Classes;
using FlightBooking.Core.Interfaces;
using FlightBooking.Core.Classes.FinanceCalculations;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using FlightBooking.Manager.Classes;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class FlightFinanceTests
    {
        private ScheduledFlight _scheduledFlight;
        private FlightManager _flightManager;

        [TestInitialize]
        public void TestInit()
        {
            TestMockData.SetupAirlineData(out _scheduledFlight, out _flightManager);
        }

        [TestMethod]
        public void TestProfitFromFlight()
        {
            IProfitCalculator profitCalculator = new ProfitCalculator();
            IFlightFinance flightFinance = new FlightFinance(_scheduledFlight, _scheduledFlight.FlightRoute, profitCalculator);
            double output = flightFinance.ProfitFromFlight();
            double profitFromFlight = 800;
            Assert.AreEqual(profitFromFlight, output);
        }

        [TestMethod]
        public void TestFlightCost()
        {
            IProfitCalculator profitCalculator = new ProfitCalculator();
            IFlightFinance flightFinance = new FlightFinance(_scheduledFlight, _scheduledFlight.FlightRoute, profitCalculator);
            double flightCost = flightFinance.CostOfFlight();            
            Assert.AreEqual(500, flightCost);
        }
    }
}
