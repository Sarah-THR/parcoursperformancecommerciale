using EcoleDeLaPerformance.API.Host.Contracts.Responses.HalfDayPlannings;
using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.TaskPlannings
{
    public class TaskPlanningResponse
    {
        public int TaskId { get; set; }

        public string Titled { get; set; } = null!;

        public string Identifier { get; set; }

    }
}
