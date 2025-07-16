namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Debriefs
{
    public class DebriefByUserRequest
    {
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
