using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities.CRM;

public partial class ContractBase
{
    public int ContractId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? OriginatingContract { get; set; }

    public int? CustomerId { get; set; }

    public int? CustomerIdType { get; set; }

    public string? CustomerIdName { get; set; }

    public int? ContractCommercial { get; set; }

    public string? CustomerIdYomiName { get; set; }

    public virtual ICollection<ContractBase> InverseOriginatingContractNavigation { get; set; } = new List<ContractBase>();

    public virtual ContractBase? OriginatingContractNavigation { get; set; }
}
