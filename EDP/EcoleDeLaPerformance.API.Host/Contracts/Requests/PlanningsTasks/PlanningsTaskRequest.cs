namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.PlanningsTasks
{
    public class PlanningsTaskRequest
    {
        public int PlanningId { get; set; }

        public int TaskId { get; set; }

        public string TimeOfDay { get; set; } = null!;

        public string Identifier { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
