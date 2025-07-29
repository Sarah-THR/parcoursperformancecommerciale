using EcoleDeLaPerformance.API.Host.Contracts.Responses.Plannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Tasks;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.PlanningsTasks
{
    public class PlanningsTaskResponse
    {
        public int PlanningId { get; set; }

        public int TaskId { get; set; }

        public string TimeOfDay { get; set; } = null!;

        public string Identifier { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual TaskResponse Task { get; set; } = null!;
    }
}
