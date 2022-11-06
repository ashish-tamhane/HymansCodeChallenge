namespace FlightBooking.FlightProceedCheck
{
    public class FlightRelaxedRuleSetValidation : IFlightValidation
    {
        public double profitSurplus { get; set; }

        public int seatsOccupied { get; set; }
        public double totalSeats { get; set; }
        public double minimumTakeOffPercentage { get; set; }

        public int totalAirLineEmployees { get; set; }        

        public FlightRelaxedRuleSetValidation()
        {

        }

        public bool ValidateCondition(out string output)
        {
            var areAirlineEmployeesMore = totalAirLineEmployees / totalSeats > minimumTakeOffPercentage;

            bool returned;
            if (areAirlineEmployeesMore)
            {
                returned = seatsOccupied < totalSeats;
                output = returned ? string.Empty : "Flight failed to pass Relaxed ruleset.";
            }
            else
            {
                returned = profitSurplus > 0 &&
                                seatsOccupied < totalSeats &&
                                seatsOccupied / totalSeats > minimumTakeOffPercentage;
                output = returned ? string.Empty : "Flight failed to pass Relaxed ruleset.";
            }

            return returned;
        }
    }
}
