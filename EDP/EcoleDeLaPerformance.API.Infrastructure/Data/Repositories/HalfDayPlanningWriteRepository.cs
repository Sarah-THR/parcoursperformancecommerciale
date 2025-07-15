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
    internal class HalfDayPlanningWriteRepository : IHalfDayPlanningWriteRepository
    {
        private readonly ParcoursPerformanceCommercialContext _ecoleDeLaPerformancePreprodContext;

        public HalfDayPlanningWriteRepository(ParcoursPerformanceCommercialContext reportitupContext)
        {
            _ecoleDeLaPerformancePreprodContext = reportitupContext;
        }

        public async Task<HalfDayPlanning> InsertHalfDayPlanningAsync(HalfDayPlanning halfDayPlanning)
        {
            _ecoleDeLaPerformancePreprodContext.HalfDayPlannings.Add(halfDayPlanning);
            await _ecoleDeLaPerformancePreprodContext.SaveChangesAsync();
            return halfDayPlanning;
        }
        public async System.Threading.Tasks.Task UpdateHalfDayPlanningAsync(HalfDayPlanning halfDayPlanning)
        {
            _ecoleDeLaPerformancePreprodContext.HalfDayPlannings.Update(halfDayPlanning);
            await _ecoleDeLaPerformancePreprodContext.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task DeleteHalfDayPlanningAsync(int halfDayPlanningId)
        {
            await _ecoleDeLaPerformancePreprodContext.HalfDayPlannings.Where(p => p.Id == halfDayPlanningId).ExecuteDeleteAsync();
        }


    }
}
