namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Briefs
{
    public class BriefByUserRequest
    {
        public int UserId { get; set; }

        public DateTime StartDateWeek { get; set; }

        public DateTime EndDateWeek { get; set; }

    }
}
