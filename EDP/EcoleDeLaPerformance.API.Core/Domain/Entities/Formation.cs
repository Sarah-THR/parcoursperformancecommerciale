using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Formation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? GradeId { get; set; }

    public Grade Grade { get; set; }

    public int? RoleId { get; set; }

    public Role Role { get; set; }

    [JsonIgnore]
    public virtual ICollection<UsersFormation> UsersFormations { get; set; } = new List<UsersFormation>();
}
