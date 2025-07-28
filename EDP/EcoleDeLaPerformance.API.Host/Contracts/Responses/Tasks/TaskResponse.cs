using EcoleDeLaPerformance.API.Host.Contracts.Responses.PlanningsTasks;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Tasks
{
    public class TaskResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Identifier { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
