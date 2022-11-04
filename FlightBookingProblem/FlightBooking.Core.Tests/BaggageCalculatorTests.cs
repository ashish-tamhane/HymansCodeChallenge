using FlightBooking.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class BaggageCalculatorTests
    {
        [TestMethod]
        public void TestChallengeBaggage()
        {
            IBaggageCalculator baggageCalculator = new BaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(TestMockData.GetPassengers());

            Assert.AreEqual(13, baggageCount);

        }

        [TestMethod]
        public void TestEachPersonBaggage()
        {
            IBaggageCalculator baggageCalculator = new BaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(TestMockData.GetEachPassenger());

            Assert.AreEqual(6, baggageCount);

        }

        [TestMethod]
        public void TestEmptyBaggage()
        {
            IBaggageCalculator baggageCalculator = new BaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(new List<IPassenger>());

            Assert.AreEqual(0, baggageCount);

        }
    }
}
