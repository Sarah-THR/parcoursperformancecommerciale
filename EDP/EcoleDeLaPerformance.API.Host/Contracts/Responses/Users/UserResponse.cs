using EcoleDeLaPerformance.API.Host.Contracts.Responses.Briefs;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Grades;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Plannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.UsersFormations;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Users
{
    public class UserResponse
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

        public virtual ICollection<BriefResponse>? Briefs { get; set; } = new List<BriefResponse>();

        public virtual ICollection<DebriefResponse>? Debriefs { get; set; } = new List<DebriefResponse>();

        public virtual UserResponse? Director { get; set; }

        public virtual ICollection<DocumentResponse>? Documents { get; set; } = new List<DocumentResponse>();

        public virtual GradeResponse? Grade { get; set; }

        public virtual ICollection<UserResponse>? InverseDirector { get; set; } = new List<UserResponse>();

        public virtual ICollection<UserResponse>? InverseSupervisor { get; set; } = new List<UserResponse>();

        public virtual ICollection<PlanningResponse>? Plannings { get; set; } = new List<PlanningResponse>();

        public virtual UserResponse? Supervisor { get; set; }

        public virtual ICollection<UsersFormationResponse>? UsersFormations { get; set; } = new List<UsersFormationResponse>();
    }

}
