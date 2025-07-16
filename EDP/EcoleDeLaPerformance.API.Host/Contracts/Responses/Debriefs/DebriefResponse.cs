using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs
{
    public class DebriefResponse
    {
        public int Id { get; set; }

        public string CompletedBusiness { get; set; } = null!;

        public string BusinessInProgress { get; set; } = null!;

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual UserResponse User { get; set; } = null!;
    }
}
