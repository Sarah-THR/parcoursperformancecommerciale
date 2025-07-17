namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Plannings
{
    public class PlanningByUserIdRequest
    {
        public int UserId { get; set; }

        public DateTime StartDateWeek { get; set; }

        public DateTime EndDateWeek { get; set; }
    }
}
