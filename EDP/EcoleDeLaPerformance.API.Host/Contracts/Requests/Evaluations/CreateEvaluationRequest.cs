namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Evaluations
{
    public class CreateEvaluationRequest
    {
        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
