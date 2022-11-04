using FlightBooking.Core.Interfaces;
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

Total passengers: 10
    General sales: 6
    Loyalty member sales: 3
    Airline employee comps: 1

Total expected baggage: 13

Total revenue from flight: 800
Total costs from flight: 500
Flight generating profit of: 300

Total loyalty points given away: 10
Total loyalty points redeemed: 100


THIS FLIGHT MAY PROCEED";

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
                Name = "Steve",
                Age = 30
            }, new LoyaltyCalculator());

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.General,
                Name = "Mark",
                Age = 12
            }, new LoyaltyCalculator());

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.General,
                Name = "James",
                Age = 36
            }, new LoyaltyCalculator());

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.General,
                Name = "Jane",
                Age = 32
            }, new LoyaltyCalculator());

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.LoyaltyMember,
                Name = "John",
                Age = 29,
                LoyaltyPoints = 1000,
                IsUsingLoyaltyPoints = true,
            }, new LoyaltyCalculator());

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.LoyaltyMember,
                Name = "Sarah",
                Age = 45,
                LoyaltyPoints = 1250,
                IsUsingLoyaltyPoints = false,
            }, new LoyaltyCalculator());

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.LoyaltyMember,
                Name = "Jack",
                Age = 60,
                LoyaltyPoints = 50,
                IsUsingLoyaltyPoints = false,
            }, new LoyaltyCalculator());

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "Trevor",
                Age = 47,
            }, new LoyaltyCalculator());

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.General,
                Name = "Alan",
                Age = 34
            }, new LoyaltyCalculator());

            _scheduledFlight.AddPassenger(new Passenger
            {
                Type = PassengerType.General,
                Name = "Suzy",
                Age = 21
            }, new LoyaltyCalculator());
        }
    }
}
