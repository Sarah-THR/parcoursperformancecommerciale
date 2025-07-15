using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities.CRM;

public partial class SystemUserBase
{
    public int SystemUserId { get; set; }

    public string? FullName { get; set; }

    public string? YomiFullName { get; set; }

}
