using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Debrief
{
    public long Id { get; set; }

    public string CompletedBusiness { get; set; } = null!;

    public string BusinessInProgress { get; set; } = null!;

    public long UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
