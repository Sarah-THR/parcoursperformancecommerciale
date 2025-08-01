
namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Users
{
    public class UserRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? ProfilePicturePath { get; set; }

        public string? Entity { get; set; }

        public DateOnly? StartFollowUp { get; set; }

        public int? SupervisorId { get; set; }

        public int? DirectorId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int? GradeId { get; set; }
    }
}
