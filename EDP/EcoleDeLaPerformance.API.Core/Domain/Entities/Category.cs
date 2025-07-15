using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Category
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
