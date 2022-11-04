using FlightBooking.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class BaggageCalculatorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IBaggageCalculator baggageCalculator = new BaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(TestMockData.GetPassengers());

            Assert.AreEqual(13, baggageCount);

        }
    }
}
