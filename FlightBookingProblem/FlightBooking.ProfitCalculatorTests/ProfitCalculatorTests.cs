using FlightBooking.Core.Classes.FinanceCalculations;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class ProfitCalculatorTests
    {
        [TestMethod]
        public void TestChallengeExample()
        {
            IProfitCalculator profitCalculator = new ProfitCalculator();
            double profit = profitCalculator.CalculateProfit(TestMockData.GetPassengers(), 100);

            Assert.AreEqual(800, profit);
        }

        [TestMethod]
        public void TestEachPersonExample()
        {
            IProfitCalculator profitCalculator = new ProfitCalculator();
            double profit = profitCalculator.CalculateProfit(TestMockData.GetEachPassenger(), 100);

            Assert.AreEqual(200, profit);
        }
    }
}
