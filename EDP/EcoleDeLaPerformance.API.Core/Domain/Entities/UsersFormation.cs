using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class UsersFormation
{
    public long UserId { get; set; }

    public long FormationId { get; set; }

    public long? StatusId { get; set; }

    public long? EvaluationId { get; set; }

    public bool IsValidated { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? DocumentId { get; set; }

    public virtual Document? Document { get; set; }

    public virtual Evaluation? Evaluation { get; set; }

    public virtual Formation Formation { get; set; } = null!;

    public virtual Status? Status { get; set; }

    public virtual User User { get; set; } = null!;
}
