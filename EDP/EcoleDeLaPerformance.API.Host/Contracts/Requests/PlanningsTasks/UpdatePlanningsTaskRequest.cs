namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.PlanningsTasks
{
    public class UpdatePlanningsTaskRequest
    {
        public int PlanningId { get; set; }

        public int TaskId { get; set; }

        public string TimeOfDay { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
