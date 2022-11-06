namespace FlightBooking.FlightProceedCheck
{
    public class FlightDefaultRuleSetValidation : IFlightValidation
    {
        public double ProfitSurplus { get; set; }
        
        public int SeatsOccupied { get; set; }
        public double TotalSeats { get; set; }
        public double MinimumTakeOffPercentage { get; set; }

        public FlightDefaultRuleSetValidation()
        {
            
        }

        public bool ValidateCondition(out string output)
        {                        
            bool returned = ProfitSurplus > 0 &&
                                SeatsOccupied < TotalSeats &&
                                SeatsOccupied / TotalSeats > MinimumTakeOffPercentage;

            string validationMessage = string.Empty;

            if (!returned)
            {
                if (ProfitSurplus > 0)
                { validationMessage = "Profit generated failed to pass as per default ruleset."; }
                else if (SeatsOccupied < TotalSeats)
                { validationMessage = "Seats occupied are more than total seats."; }
                else if (SeatsOccupied / TotalSeats > MinimumTakeOffPercentage)
                { validationMessage = "Minimum number of seats occupied not as per required percentage."; }
            }
            output = validationMessage;

            return returned;
        }
    }
}
