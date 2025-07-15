using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Infrastructure.Data.Repositories
{
    public class HalfDayPlanningReadRepository : IHalfDayPlanningReadRepository
    {
        private readonly ParcoursPerformanceCommercialContext _ecoleDeLaPerformancePreprodContext;

        public HalfDayPlanningReadRepository(ParcoursPerformanceCommercialContext ecoleDeLaPerformancePreprodContext)
        {
            _ecoleDeLaPerformancePreprodContext = ecoleDeLaPerformancePreprodContext;
        }

        public async Task<IEnumerable<HalfDayPlanning?>> GetHalfDayPlanningByWeekIdAsync(int weekId)
        {
            return await _ecoleDeLaPerformancePreprodContext.HalfDayPlannings
                            .Include(x => x.Week)
                            .Include(x => x.Task)
                            .Where(u => u.WeekId == weekId).ToListAsync();
        }
    }
}
