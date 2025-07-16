namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Statuses
{
    public class StatusRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
