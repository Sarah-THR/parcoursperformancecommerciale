using EcoleDeLaPerformance.API.Host.Contracts.Responses.Categories;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.UsersFormations;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents
{
    public class DocumentResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ContentPath { get; set; } = null!;

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? CategoryId { get; set; }

        public virtual CategoryResponse? Category { get; set; }

        public virtual UserResponse User { get; set; } = null!;

        public virtual ICollection<UsersFormationResponse> UsersFormations { get; set; } = new List<UsersFormationResponse>();
    }
}
