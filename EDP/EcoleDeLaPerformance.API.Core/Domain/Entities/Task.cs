namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Identifier { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<PlanningsTask> PlanningsTasks { get; set; } = new List<PlanningsTask>();
}
