using FlightBooking.Core.Classes;
using FlightBooking.Core.Entities;
using FlightBooking.Core.Enumerations;
using FlightBooking.Core.Classes.FinanceCalculations;
using FlightBooking.Core.Interfaces.FinanceCalculations;
using System;

namespace FlightBookingProblem
{
    class Program
    {
        private static ScheduledFlight _scheduledFlight ;
        private static FlightManager flightManager;

        static void Main(string[] args)
        {
            SetupAirlineData();
            
            string command = "";
            do
            {
                command = Console.ReadLine() ?? "";
                var enteredText = command.ToLower();
                if (enteredText.Contains("print summary"))
                {
                    Console.WriteLine();
                    
                    FlightInformation flightInformation = _scheduledFlight.GetFlightInformation();
                    
                    FlightFinance flightFinance = new FlightFinance(_scheduledFlight, _scheduledFlight.FlightRoute, new ProfitCalculator());
                    flightInformation.costOfFlight = flightFinance.CostOfFlight();
                    flightInformation.profitFromFlight = flightFinance.ProfitFromFlight();
                    flightInformation.profitSurplus = flightFinance.ProfitSurplus();                    
                    
                    flightInformation.totalLoyaltyPointsAccrued = flightManager.TotalLoyaltyPointsAccrued;
                    flightInformation.totalLoyaltyPointsRedeemed = flightManager.TotalLoyaltyPointsRedeemed;

                    Console.WriteLine(SummaryGenerator.GenerateSummary(_scheduledFlight.Passengers, flightInformation, flightManager));
                }
                else if (enteredText.Contains("add general"))
                {
                    string[] passengerSegments = enteredText.Split(' ');
                    flightManager.AddPassenger(new Passenger
                    {
                        Type = PassengerType.General, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3])
                    });
                }
                else if (enteredText.Contains("add loyalty"))
                {
                    string[] passengerSegments = enteredText.Split(' ');
                    flightManager.AddPassenger(new Passenger
                    {
                        Type = PassengerType.LoyaltyMember, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3]),
                        LoyaltyPoints = Convert.ToInt32(passengerSegments[4]),
                        IsUsingLoyaltyPoints = Convert.ToBoolean(passengerSegments[5]),
                    });
                }
                else if (enteredText.Contains("add airline"))
                {
                    string[] passengerSegments = enteredText.Split(' ');
                    flightManager.AddPassenger(new Passenger
                    {
                        Type = PassengerType.AirlineEmployee, 
                        Name = passengerSegments[2], 
                        Age = Convert.ToInt32(passengerSegments[3]),
                    });
                }
                else if (enteredText.Contains("exit"))
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("UNKNOWN INPUT");
                    Console.ResetColor();
                }
            } while (command != "exit");
        }

        private static void SetupAirlineData()
        {
            FlightRoute londonToParis = new FlightRoute("London", "Paris")
            {
                BaseCost = 50, 
                BasePrice = 100, 
                LoyaltyPointsGained = 5,
                MinimumTakeOffPercentage = 0.7
            };

            _scheduledFlight = new ScheduledFlight(londonToParis,                 
                new BaggageCalculator(),
                new Plane { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 });

            IFlightFinance flightFinance = new FlightFinance(_scheduledFlight, londonToParis, new ProfitCalculator());

            flightManager = new FlightManager(_scheduledFlight,
                _scheduledFlight.FlightRoute, 
                new LoyaltyPointsCalculator(), flightFinance);
        }
    }
}
