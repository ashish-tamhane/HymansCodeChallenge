using FlightBooking.Core.Entities;
using FlightBooking.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.Classes
{
    public class ScheduledFlight : IScheduledFlight
    {
        private readonly Plane aircraft;
        private readonly List<Passenger> passengers;
        private readonly IBaggageCalculator baggageCalculator;
        private readonly IFlightRoute flightRoute;

        public IFlightRoute FlightRoute => flightRoute;

        public List<Passenger> Passengers => passengers;
        public int SeatsOccupied => Passengers.Count();

        public ScheduledFlight(IFlightRoute flightRoute,
            IBaggageCalculator baggageCalculator,
            Plane plane)
        {
            this.flightRoute = flightRoute;
            this.baggageCalculator = baggageCalculator;
            passengers = new List<Passenger>();
            aircraft = plane;
        }

        public void AddPassenger(Passenger passenger) => passengers.Add(passenger);


        public int GetExpectedBaggageFromFlight() => baggageCalculator.CalculateBaggage(passengers);

        public FlightInformation GetFlightInformation()
        {
            double flightRouteMinimumTakeOffPercentage = flightRoute.MinimumTakeOffPercentage;
            string flightRouteTitle = flightRoute.Title;
            int aircraftNumberOfSeats = aircraft.NumberOfSeats;
            int seatsTaken = SeatsOccupied;
            int expectedBaggageFromFlight = GetExpectedBaggageFromFlight();

            return new FlightInformation()
            {
                seatsTaken = seatsTaken,
                expectedBaggageFromFlight = expectedBaggageFromFlight,
                flightRouteTitle = flightRouteTitle,
                aircraftNumberOfSeats = aircraftNumberOfSeats,
                flightRouteMinimumTakeOffPercentage = flightRouteMinimumTakeOffPercentage
            };
        }
    }
}
