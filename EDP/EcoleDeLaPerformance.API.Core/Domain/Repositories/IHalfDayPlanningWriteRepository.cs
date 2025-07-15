using EcoleDeLaPerformance.API.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IHalfDayPlanningWriteRepository
    {
        Task<HalfDayPlanning> InsertHalfDayPlanningAsync(HalfDayPlanning halfDayPlanning);
        System.Threading.Tasks.Task UpdateHalfDayPlanningAsync(HalfDayPlanning halfDayPlanning);
        System.Threading.Tasks.Task DeleteHalfDayPlanningAsync(int halfDayPlanningId);
    }
}
