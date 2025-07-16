namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Evaluations
{
    public class EvaluationRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
