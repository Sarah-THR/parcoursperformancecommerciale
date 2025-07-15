using EcoleDeLaPerformance.API.Host.Contracts.Responses.TaskPlannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Weeks;
using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.HalfDayPlannings
{
    public class HalfDayPlanningResponse
    {
        public int HalfDayId { get; set; }

        public bool? HalfDayTime { get; set; }
        public DateTime HalfDayDate { get; set; }

        public int WeekId { get; set; }

        public int TaskId { get; set; }

        public virtual TaskPlanningResponse Task { get; set; } = null!;

        public virtual WeekResponse Week { get; set; } = null!;
    }
}
