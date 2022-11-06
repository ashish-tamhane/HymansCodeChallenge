using System;

namespace FlightBooking.FlightProceedCheck
{
    public interface IFlightValidation
    {
        bool ValidateCondition(out string output);
    }
}
