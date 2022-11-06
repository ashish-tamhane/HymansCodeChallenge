using FlightBooking.BaggageCalculator.Classes;
using FlightBooking.BaggageCalculator.Interfaces;
using FlightBooking.Core.Classes;
using FlightBooking.Entities.Models;
using FlightBooking.Manager.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class BaggageCalculatorTests
    {
        private static ScheduledFlight scheduledFlight;
        private FlightManager flightManager;

        [TestMethod]
        public void TestChallengeBaggage()
        {
            IBaggageCalculator baggageCalculator = new FlightBaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(TestMockData.GetPassengers());

            Assert.AreEqual(13, baggageCount);

        }

        [TestMethod]
        public void TestChallengeBaggageWithDiscountedPassenger()
        {
            IBaggageCalculator baggageCalculator = new FlightBaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(TestMockData.GetPassengersWithDiscountedPassenger());

            Assert.AreEqual(13, baggageCount);

        }

        [TestMethod]
        public void TestDiscountedPassengerBaggage()
        {
            IBaggageCalculator baggageCalculator = new FlightBaggageCalculator();

            int baggageCount = baggageCalculator.CalculateBaggage(TestMockData.GetEachPassengerWithDiscountedPassenger());

            Assert.AreEqual(6, baggageCount);

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

        [TestMethod]
        public void TestBaggageFromFlight()
        {
            TestMockData.SetupAirlineData(out scheduledFlight, out flightManager);
            int output = scheduledFlight.GetExpectedBaggageFromFlight();
            int expectedBaggageFromFlight = 13;

            Assert.AreEqual(expectedBaggageFromFlight, output);
        }
    }
}
