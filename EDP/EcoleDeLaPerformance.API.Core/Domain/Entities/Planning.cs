using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Planning
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<PlanningsTask> PlanningsTasks { get; set; } = new List<PlanningsTask>();

    public virtual User User { get; set; } = null!;
}
