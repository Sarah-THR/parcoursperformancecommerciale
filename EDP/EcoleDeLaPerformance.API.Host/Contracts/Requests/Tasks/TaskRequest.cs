namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Tasks
{
    public class TaskRequest
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
