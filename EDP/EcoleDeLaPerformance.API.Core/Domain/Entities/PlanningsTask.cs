using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class PlanningsTask
{
    public long PlanningId { get; set; }

    public long TaskId { get; set; }

    public string TimeOfDay { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Planning Planning { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
