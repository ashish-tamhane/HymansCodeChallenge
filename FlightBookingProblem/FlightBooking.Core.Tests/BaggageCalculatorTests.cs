using FlightBooking.Core.Classes;
using FlightBooking.Entities.Models;
using FlightBooking.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FlightBooking.BaggageCalculator.Interfaces;
using FlightBooking.BaggageCalculator.Classes;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class BaggageCalculatorTests
    {
        [TestMethod]
        public void TestChallengeBaggage()
        {
            IBaggageCalculator baggageCalculator = new FlightBaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(TestMockData.GetPassengers());

            Assert.AreEqual(13, baggageCount);

        }

        [TestMethod]
        public void TestEachPersonBaggage()
        {
            IBaggageCalculator baggageCalculator = new FlightBaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(TestMockData.GetEachPassenger());

            Assert.AreEqual(6, baggageCount);

        }

        [TestMethod]
        public void TestEmptyBaggage()
        {
            IBaggageCalculator baggageCalculator = new FlightBaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(new List<Passenger>());

            Assert.AreEqual(0, baggageCount);

        }
    }
}
