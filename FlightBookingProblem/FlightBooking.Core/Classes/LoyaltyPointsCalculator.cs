using FlightBooking.Core.Entities;
using FlightBooking.Core.Enumerations;
using FlightBooking.Core.Interfaces;
using System;

namespace FlightBooking.Core.Classes
{
    public class LoyaltyPointsCalculator : ILoyaltyPointsCalculator
    {
        public bool CalculateLoyaltyPoints(Passenger passenger, IFlightRoute flightRoute, out int totalLoyaltyPointsRedeemed, out int totalLoyaltyPointsAccrued)
        {
            totalLoyaltyPointsRedeemed = 0;
            totalLoyaltyPointsAccrued = 0;
            bool returned = false;

            if (passenger.Type == PassengerType.LoyaltyMember)
            {
                returned = true;
                if (passenger.IsUsingLoyaltyPoints)
                {
                    int loyaltyPointsRedeemed = Convert.ToInt32(Math.Ceiling(flightRoute.BasePrice));
                    passenger.LoyaltyPoints -= loyaltyPointsRedeemed;
                    totalLoyaltyPointsRedeemed += loyaltyPointsRedeemed;
                }
                else
                {
                    totalLoyaltyPointsAccrued += flightRoute.LoyaltyPointsGained;
                }
            }

            return returned;
        }
    }
}