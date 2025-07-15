using EcoleDeLaPerformance.API.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IHalfDayPlanningReadRepository
    {
        Task<IEnumerable<HalfDayPlanning?>> GetHalfDayPlanningByWeekIdAsync(int weekId);
    }
}
