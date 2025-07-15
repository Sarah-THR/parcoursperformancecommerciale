using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Brief
{
    public long Id { get; set; }

    public string SignatureCommitment { get; set; } = null!;

    public string FilesToCheck { get; set; } = null!;

    public string Note { get; set; } = null!;

    public long UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
