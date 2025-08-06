using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Briefs
{
    public class BriefResponse
    {
        public int Id { get; set; }

        public string? SignatureCommitment { get; set; }

        public string? FilesToCheck { get; set; } 

        public string? Note { get; set; }

        public int UserId { get; set; }

        public bool IsDraft { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual UserResponse User { get; set; } = null!;
    }
}
