namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Debriefs
{
    public class DebriefByUserRequest
    {
        public int UserId { get; set; }

        public DateTime StartDateWeek { get; set; }

        public DateTime EndDateWeek { get; set; }
    }
}
