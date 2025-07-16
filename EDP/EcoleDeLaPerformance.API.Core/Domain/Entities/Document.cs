namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Document
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string ContentPath { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UsersFormation> UsersFormations { get; set; } = new List<UsersFormation>();
}
