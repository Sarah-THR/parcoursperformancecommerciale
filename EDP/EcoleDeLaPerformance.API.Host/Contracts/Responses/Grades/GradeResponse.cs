using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Grades
{
    public class GradeResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
