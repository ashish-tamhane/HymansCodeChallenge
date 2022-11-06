using FlightBooking.BaggageCalculator.Classes;
using FlightBooking.Core.Classes;
using FlightBooking.Core.Classes.FinanceCalculations;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using FlightBooking.Entities.Enumerations;
using FlightBooking.Entities.Models;
using FlightBooking.FlightProceedCheck;
using FlightBooking.Manager.Classes;
using System.Collections.Generic;

namespace FlightBooking.Core.Tests
{
    public static class TestMockData
    {
        public static string ExpectedConsoleOutputForTooManyPassengers = @"Flight summary for London to Paris

Total passengers: 16
    General sales: 4
    Loyalty member sales: 8
    Discounted member sales: 0
    Airline employee comps: 4

Total expected baggage: 24

Total revenue from flight: 800
Total costs from flight: 800
Flight losing money of: 0

Total loyalty points given away: 20
Total loyalty points redeemed: 400


THIS FLIGHT MAY NOT PROCEED";

        public static string ExpectedConsoleOutputForDefaultRuleSetWithMoreAirlineEmployees = @"Flight summary for London to Paris

Total passengers: 12
    General sales: 2
    Loyalty member sales: 0
    Discounted member sales: 0
    Airline employee comps: 10

Total expected baggage: 12

Total revenue from flight: 200
Total costs from flight: 600
Flight losing money of: -400

Total loyalty points given away: 0
Total loyalty points redeemed: 0


THIS FLIGHT MAY NOT PROCEED";

        public static string ExpectedConsoleOutputForRelaxedRuleSet = @"Flight summary for London to Paris

Total passengers: 12
    General sales: 2
    Loyalty member sales: 0
    Discounted member sales: 0
    Airline employee comps: 10

Total expected baggage: 12

Total revenue from flight: 200
Total costs from flight: 600
Flight losing money of: -400

Total loyalty points given away: 0
Total loyalty points redeemed: 0


THIS FLIGHT MAY PROCEED";

        public static string ExpectedConsoleOutput = @"Flight summary for London to Paris

Total passengers: 10
    General sales: 6
    Loyalty member sales: 3
    Discounted member sales: 0
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

        public static List<Passenger> GetEachPassengerWithDiscountedPassenger()
        {
            var passengers = GetEachPassenger();

            passengers.Add(new Passenger()
            {
                Age = 20,
                AllowedBags = 10,
                IsUsingLoyaltyPoints = true,
                LoyaltyPoints = 50,
                Type = PassengerType.Discounted,
                Name = "DiscountedPassenger"
            });

            return passengers;
        }

        public static List<Passenger> GetPassengersWithDiscountedPassenger()
        {
            var passengers = GetPassengers();

            passengers.Add(new Passenger()
            {
                Age = 20,
                AllowedBags = 10,
                IsUsingLoyaltyPoints = true,
                LoyaltyPoints = 50,
                Type = PassengerType.Discounted,
                Name = "DiscountedPassenger"
            });

            return passengers;
        }

        public static List<Passenger> GetTooManyPassengers()
        {
            var passengersArray = GetEachPassenger();

            passengersArray.AddRange(GetEachPassenger());
            passengersArray.AddRange(GetEachPassenger());
            passengersArray.AddRange(GetEachPassenger());

            return passengersArray;
        }
        public static List<Passenger> GetPassengersForRelaxedRuleset()
        {
            var passengersArray = new[] { new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "Steve",
                Age = 30
            }, new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "Joe",
                Age = 12
            }, new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "Gavin",
                Age = 36
            },
                new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "Neil",
                Age = 12
            }, new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "James",
                Age = 36
            }, new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "Jane",
                Age = 32
            }, new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "John",
                Age = 29,
                LoyaltyPoints = 1000,
                IsUsingLoyaltyPoints = true,
            }, new Passenger
            {
                Type = PassengerType.AirlineEmployee,
                Name = "Sarah",
                Age = 45,
                LoyaltyPoints = 1250,
                IsUsingLoyaltyPoints = false,
            },

            new Passenger
            {
                Type = PassengerType.AirlineEmployee,
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

            flightManager = new FlightManager(_scheduledFlight, londonToParis, new LoyaltyPointsCalculator(), flightFinance, FlightValidationType.DefaultRuleset);
            flightManager.AddPassengers(GetPassengers());
        }

        public static void SetupAirlineDataForTooManyPassengers(out ScheduledFlight _scheduledFlight, out FlightManager flightManager)
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

            flightManager = new FlightManager(_scheduledFlight, londonToParis, new LoyaltyPointsCalculator(), flightFinance, FlightValidationType.DefaultRuleset);
            flightManager.AddPassengers(GetTooManyPassengers());
        }

        public static void SetupAirlineDataForRelaxedRuleSet(out ScheduledFlight _scheduledFlight, out FlightManager flightManager)
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

            flightManager = new FlightManager(_scheduledFlight, londonToParis, new LoyaltyPointsCalculator(), flightFinance, FlightValidationType.DefaultRuleset);
            flightManager.AddPassengers(GetPassengersForRelaxedRuleset());
        }
    }
}
