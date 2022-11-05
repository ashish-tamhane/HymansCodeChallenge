using FlightBooking.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FlightBooking.Core.Classes
{
    public class ScheduledFlight : IScheduledFlight
    {
        private readonly IPlane Aircraft;
        private readonly List<IPassenger> passengers;
        private readonly IBaggageCalculator baggageCalculator;
        private readonly IFlightRoute flightRoute;

        public IFlightRoute FlightRoute => flightRoute;

        public List<IPassenger> Passengers => passengers;

        public ScheduledFlight(IFlightRoute flightRoute,
            IBaggageCalculator baggageCalculator,
            IPlane plane
            )
        {
            this.flightRoute = flightRoute;
            this.baggageCalculator = baggageCalculator;
            passengers = new List<IPassenger>();
            Aircraft = plane;
        }

        public void AddPassenger(IPassenger passenger)
        {
            passengers.Add(passenger);
        }

        public void AddPassengers(IEnumerable<IPassenger> passengers)
        {
            passengers.ToList().ForEach(p => AddPassenger(p));
        }


        public int GetExpectedBaggageFromFlight()
        {
            return baggageCalculator.CalculateBaggage(passengers);
        }

        public int GetSeatsTaken()
        {
            return passengers.Count();
        }

        public FlightInformation GetFlightInformation()
        {
            double flightRouteMinimumTakeOffPercentage = flightRoute.MinimumTakeOffPercentage;
            string flightRouteTitle = flightRoute.Title;
            int aircraftNumberOfSeats = Aircraft.NumberOfSeats;
            int seatsTaken = GetSeatsTaken();
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
