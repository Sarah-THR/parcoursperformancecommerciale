namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Briefs
{
    public class BriefByUserRequest
    {
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
