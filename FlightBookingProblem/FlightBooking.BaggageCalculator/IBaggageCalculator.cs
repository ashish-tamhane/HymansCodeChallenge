using FlightBooking.Entities.Models;
using System.Collections.Generic;

namespace FlightBooking.BaggageCalculator.Interfaces
{
    public interface IBaggageCalculator
    {
        int CalculateBaggage(List<Passenger> passengers);
    }
}