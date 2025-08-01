﻿namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class Debrief
{
    public int Id { get; set; }

    public string CompletedBusiness { get; set; } = null!;

    public string BusinessInProgress { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
