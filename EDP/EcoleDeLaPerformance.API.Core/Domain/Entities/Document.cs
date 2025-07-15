using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Document
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string ContentPath { get; set; } = null!;

    public long UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UsersFormation> UsersFormations { get; set; } = new List<UsersFormation>();
}
