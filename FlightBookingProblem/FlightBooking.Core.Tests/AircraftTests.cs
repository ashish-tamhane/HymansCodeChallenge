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

        [TestMethod]
        public void TestDefaultPlanes()
        {
            var planes = PlanesList.Planes;

            CollectionAssert.AllItemsAreUnique(planes);

            Assert.AreEqual(planes.First(p => p.Name == "Antonov AN-2").Name, "Antonov AN-2");
            Assert.AreEqual(planes.First(p => p.Name == "Bombardier Q400").Name, "Bombardier Q400");
            Assert.AreEqual(planes.First(p => p.Name == "ATR 640").Name, "ATR 640");
        }
    }
}
