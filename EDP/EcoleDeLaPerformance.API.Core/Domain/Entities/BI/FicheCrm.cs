using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities.BI;

public partial class FicheCrm
{
    public string? Nom { get; set; }

    public string? Agence { get; set; }

    public string? Relation { get; set; }

    public string? NuméroSage { get; set; }

    public string? Commercial { get; set; }

    public int Accountid { get; set; }

    public int? Agenceid { get; set; }

    public long? Slot { get; set; }

    public int? SlotCrm { get; set; }

    public int? Commercialid { get; set; }
}
