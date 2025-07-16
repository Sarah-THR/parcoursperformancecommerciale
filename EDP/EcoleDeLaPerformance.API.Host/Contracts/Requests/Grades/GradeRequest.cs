namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Grades
{
    public class GradeRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
