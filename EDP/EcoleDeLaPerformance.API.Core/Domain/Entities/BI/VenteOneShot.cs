using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities.BI
{
    public class VenteOneShot
    {
        public DateOnly do_date { get; set; }

        public string co_nom { get; set; }

        public int nb { get; set; }
    }
}
