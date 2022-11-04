using FlightBooking.Core.Classes;
using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IScheduledFlight
    {        
        void AddPassenger(IPassenger passenger);
        string GetSummary();        
    }
}