namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class PlanningsTask
{
    public int PlanningId { get; set; }

    public int TaskId { get; set; }

    public string TimeOfDay { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Planning Planning { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
