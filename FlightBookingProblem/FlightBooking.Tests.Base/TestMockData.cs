using FlightBooking.Core.Classes;
using FlightBooking.Core.Classes.FinanceCalculations;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using FlightBooking.Entities.Models;
using FlightBooking.Entities.Enumerations;
using FlightBooking.Manager.Classes;
using System.Collections.Generic;
using FlightBooking.BaggageCalculator.Classes;

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

        public static List<Passenger> GetEachPassenger()
        {
            var passengersArray = new[] { new Passenger
            {
                Type = PassengerType.General,
                Name = "Steve",
                Age = 30
            },
            new Passenger
            {
                Type = PassengerType.LoyaltyMember,
                Name = "Black",
                Age = 60,
                LoyaltyPoints = 50,
                IsUsingLoyaltyPoints = true,
            },
            new Passenger
            {
                Type = PassengerType.LoyaltyMember,
                Name = "Jack",
                Age = 60,
                LoyaltyPoints = 50,
                IsUsingLoyaltyPoints = false,
            }, new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "Trevor",
                Age = 47,
            }};

            List<Passenger> passengers = new List<Passenger>();
            passengers.AddRange(passengersArray);

            return passengers;
        }

        public static List<Passenger> GetPassengers()
        {
            var passengersArray = new[] { new Passenger
            {
                Type = PassengerType.General,
                Name = "Steve",
                Age = 30
            }, new Passenger
            {
                Type = PassengerType.General,
                Name = "Mark",
                Age = 12
            }, new Passenger
            {
                Type = PassengerType.General,
                Name = "James",
                Age = 36
            }, new Passenger
            {
                Type = PassengerType.General,
                Name = "Jane",
                Age = 32
            }, new Passenger
            {
                Type = PassengerType.LoyaltyMember,
                Name = "John",
                Age = 29,
                LoyaltyPoints = 1000,
                IsUsingLoyaltyPoints = true,
            }, new Passenger
            {
                Type = PassengerType.LoyaltyMember,
                Name = "Sarah",
                Age = 45,
                LoyaltyPoints = 1250,
                IsUsingLoyaltyPoints = false,
            },

            new Passenger
            {
                Type = PassengerType.LoyaltyMember,
                Name = "Jack",
                Age = 60,
                LoyaltyPoints = 50,
                IsUsingLoyaltyPoints = false,
            }, new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "Trevor",
                Age = 47,
            },

            new Passenger
            {
                Type = PassengerType.General,
                Name = "Alan",
                Age = 34
            },

            new Passenger
            {
                Type = PassengerType.General,
                Name = "Suzy",
                Age = 21
            } };

            List<Passenger> passengers = new List<Passenger>();
            passengers.AddRange(passengersArray);

            return passengers;
        }

        public static void SetupAirlineData(out ScheduledFlight _scheduledFlight, out FlightManager flightManager)
        {            
            FlightRoute londonToParis = new FlightRoute("London", "Paris")
            {
                BaseCost = 50,
                BasePrice = 100,
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.7
            };

            _scheduledFlight = new ScheduledFlight(londonToParis,
                new FlightBaggageCalculator(),
                new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 });

            IFlightFinance flightFinance = new FlightFinance(_scheduledFlight, londonToParis, new ProfitCalculator());

            flightManager = new FlightManager(_scheduledFlight, londonToParis, new LoyaltyPointsCalculator(), flightFinance);
            flightManager.AddPassengers(GetPassengers());                        
        }
    }
}
