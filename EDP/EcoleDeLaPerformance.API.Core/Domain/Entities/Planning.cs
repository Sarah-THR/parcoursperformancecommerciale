namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Planning
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<PlanningsTask> PlanningsTasks { get; set; } = new List<PlanningsTask>();

    public virtual User User { get; set; } = null!;
}
