using FlightBooking.Entities.Models;
using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IBaggageCalculator
    {
        int CalculateBaggage(List<Passenger> passengers);
    }
}