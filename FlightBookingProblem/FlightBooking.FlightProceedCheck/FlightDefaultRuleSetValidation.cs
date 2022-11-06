namespace FlightBooking.FlightProceedCheck
{
    public class FlightDefaultRuleSetValidation : IFlightValidation
    {
        public double profitSurplus { get; set; }
        
        public int seatsOccupied { get; set; }
        public double totalSeats { get; set; }
        public double minimumTakeOffPercentage { get; set; }

        public FlightDefaultRuleSetValidation()
        {
            
        }

        public bool ValidateCondition(out string output)
        {                        
            bool returned = profitSurplus > 0 &&
                                seatsOccupied < totalSeats &&
                                seatsOccupied / totalSeats > minimumTakeOffPercentage;

            output = returned ? string.Empty : "Flight failed to pass Default ruleset.";
            
            return returned;
        }
    }
}
