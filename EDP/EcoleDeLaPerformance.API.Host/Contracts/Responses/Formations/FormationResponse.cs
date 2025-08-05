using EcoleDeLaPerformance.API.Host.Contracts.Responses.Grades;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Formations
{
    public class FormationResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int GradeId { get; set; }

        public GradeResponse Grade { get; set; }
    }
}
