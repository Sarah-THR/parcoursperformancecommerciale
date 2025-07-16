namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Grades
{
    public class CreateGradeRequest
    {
        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
