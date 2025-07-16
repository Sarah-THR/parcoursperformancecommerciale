using EcoleDeLaPerformance.API.Host.Contracts.Responses.UsersFormations;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Statuses
{
    public class StatusResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<UsersFormationResponse> UsersFormations { get; set; } = new List<UsersFormationResponse>();
    }
}
