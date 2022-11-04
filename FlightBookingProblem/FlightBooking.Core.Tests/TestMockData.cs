using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Core.Tests
{
    public static class TestMockData
    {
        public static string ExpectedConsoleOutput = @"Flight summary for London to Paris

Total passengers: 3
    General sales: 3
    Loyalty member sales: 0
    Airline employee comps: 0

Total expected baggage: 3

Total revenue from flight: 300
Total costs from flight: 150
Flight generating profit of: 150

Total loyalty points given away: 0
Total loyalty points redeemed: 0


FLIGHT MAY NOT PROCEED";

        public static void SetupAirlineData(out ScheduledFlight _scheduledFlight)
        {
            FlightRoute londonToParis = new FlightRoute("London", "Paris")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.7
            };

            _scheduledFlight = new ScheduledFlight(londonToParis);

            _scheduledFlight.SetAircraftForRoute(
                new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 });
            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.General,
                Name = "Passenger1",
                Age = 35
            });

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.General,
                Name = "Passenger2",
                Age = 40
            });

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.General,
                Name = "Passenger3",
                Age = 45
            });
        }
    }
}
