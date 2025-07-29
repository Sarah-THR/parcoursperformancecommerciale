namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Briefs
{
    public class BriefRequest
    {
        public int Id { get; set; }

        public string? SignatureCommitment { get; set; }

        public string? FilesToCheck { get; set; } 

        public string? Note { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
