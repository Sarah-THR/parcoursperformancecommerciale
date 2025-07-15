using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities.CRM;

public partial class AccountBase
{
    public int AccountId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? XefiMoyendepaiement { get; set; }

}
