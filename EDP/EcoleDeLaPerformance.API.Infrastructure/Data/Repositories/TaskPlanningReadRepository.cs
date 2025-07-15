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
    public class TaskPlanningReadRepository:ITaskPlanningReadRepository
    {
        private readonly ParcoursPerformanceCommercialContext _ecoleDeLaPerformancePreprodContext;

        public TaskPlanningReadRepository(ParcoursPerformanceCommercialContext ecoleDeLaPerformancePreprodContext)
        {
            _ecoleDeLaPerformancePreprodContext = ecoleDeLaPerformancePreprodContext;
        }

        public async Task<List<Core.Domain.Entities.Task?>> GetAllTaskPlanning()
        {
            return await _ecoleDeLaPerformancePreprodContext.Tasks.ToListAsync();
        }
    }
}
