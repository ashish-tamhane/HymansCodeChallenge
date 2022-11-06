namespace FlightBooking.FlightProceedCheck
{
    public class FlightRelaxedRuleSetValidation : IFlightValidation
    {
        public double ProfitSurplus { get; set; }

        public int SeatsOccupied { get; set; }
        public double TotalSeats { get; set; }
        public double MinimumTakeOffPercentage { get; set; }

        public int TotalAirLineEmployees { get; set; }        

        public FlightRelaxedRuleSetValidation()
        {

        }

        public bool ValidateCondition(out string output)
        {
            var areAirlineEmployeesMore = TotalAirLineEmployees / TotalSeats > MinimumTakeOffPercentage;

            bool returned;
            output = string.Empty;

            if (areAirlineEmployeesMore)
            {
                returned = SeatsOccupied <= TotalSeats;
                output = returned ? string.Empty : "Flight failed to pass Relaxed ruleset.";
            }
            else
            {
                returned = ProfitSurplus > 0 &&
                                SeatsOccupied < TotalSeats &&
                                SeatsOccupied / TotalSeats > MinimumTakeOffPercentage;

                if (!returned)
                {
                    if (ProfitSurplus < 0)
                    { output = "Profit generated failed to pass as per default ruleset."; }
                    else if (SeatsOccupied > TotalSeats)
                    { output = "Seats occupied are more than total seats."; }
                    else if (SeatsOccupied / TotalSeats < MinimumTakeOffPercentage)
                    { output = "Minimum number of seats occupied not as per required percentage."; }
                }                
            }

            return returned;
        }
    }
}
