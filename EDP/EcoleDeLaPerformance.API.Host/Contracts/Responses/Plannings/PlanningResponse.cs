using EcoleDeLaPerformance.API.Host.Contracts.Responses.PlanningsTasks;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Plannings
{
    public class PlanningResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<PlanningsTaskResponse> PlanningsTasks { get; set; } = new List<PlanningsTaskResponse>();

        public virtual UserResponse User { get; set; } = null!;
    }
}
