using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IBaggageCalculator
    {
        int CalculateBaggage(List<IPassenger> passengers);
    }
}