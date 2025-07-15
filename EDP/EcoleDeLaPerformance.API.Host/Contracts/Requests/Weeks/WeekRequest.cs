namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Weeks
{
    public class WeekRequest
    {
        public int WeekId { get; set; }
        public int WeekNumber { get; set; }

        public int PeriodNumber { get; set; }

        public DateOnly StartDateWeek { get; set; }

        public DateOnly EndDateWeek { get; set; }
        public bool Draft { get; set; }

        public int UserId { get; set; }
    }
}
