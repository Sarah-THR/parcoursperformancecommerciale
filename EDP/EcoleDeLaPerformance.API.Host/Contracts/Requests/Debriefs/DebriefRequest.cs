namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Debriefs
{
    public class DebriefRequest
    {
        public int Id { get; set; }

        public string? CompletedBusiness { get; set; }

        public string? BusinessInProgress { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
