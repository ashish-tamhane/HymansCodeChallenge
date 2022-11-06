using FlightBooking.Core.Classes;
using FlightBooking.Entities.Enumerations;
using FlightBooking.Entities.Models;
using FlightBooking.Manager.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FlightBooking.Core.Tests
{
    [TestClass]
    public class AircraftTests
    {
        private static ScheduledFlight scheduledFlight;
        private FlightManager flightManager;

        [TestMethod]
        public void TestAvailablePlanes()
        {
            TestMockData.SetupAirlineData(out scheduledFlight, out flightManager);
            flightManager.AddPassenger(new Passenger() { Type = PassengerType.General });
            flightManager.AddPassenger(new Passenger() { Type = PassengerType.General });
            flightManager.AddPassenger(new Passenger() { Type = PassengerType.General });
            flightManager.AddPassenger(new Passenger() { Type = PassengerType.General });

            Assert.AreEqual(1, flightManager.AvailablePlanes(flightManager.GetFlightInformation().seatsTaken).Count());
        }
    }
}
