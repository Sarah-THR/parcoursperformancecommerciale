using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities.BI;

public partial class EcolePerformanceSm
{
    public DateOnly? DateSignature { get; set; }

    public string? Maintenance { get; set; }

    public string? Sauvegarde { get; set; }

    public string? Sécurité { get; set; }

    public string? Commercial { get; set; }
}
