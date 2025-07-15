using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Status
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<UsersFormation> UsersFormations { get; set; } = new List<UsersFormation>();
}
