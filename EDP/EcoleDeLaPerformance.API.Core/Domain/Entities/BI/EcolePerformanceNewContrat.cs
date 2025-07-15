using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities.BI;

public partial class EcolePerformanceNewContrat
{
    public string? ContractNumber { get; set; }

    public DateOnly? DateContrat { get; set; }

    public string? Agence { get; set; }

    public string? Commercial { get; set; }
}
