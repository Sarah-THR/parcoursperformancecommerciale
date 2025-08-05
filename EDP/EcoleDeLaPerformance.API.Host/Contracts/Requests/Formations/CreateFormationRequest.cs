namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Formations
{
    public class CreateFormationRequest
    {
        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int GradeId { get; set; }

    }
}
