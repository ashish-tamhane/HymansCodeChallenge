using FlightBooking.Core.Classes;
using FlightBooking.Core.Entities;
using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IBaggageCalculator
    {
        int CalculateBaggage(List<Passenger> passengers);
    }
}