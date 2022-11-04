﻿using System.Collections.Generic;

namespace FlightBooking.Core.Interfaces
{
    public interface IProfitCalculator
    {
        double CalculateProfit(IEnumerable<IPassenger> passengerCollection, double basePrice);
    }
}