using EcoleDeLaPerformance.API.Host.Contracts.Responses.HalfDayPlannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.SignedContracts;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Weeks
{
    public class WeekResponse
    {
        public int WeekId { get; set; }

        public int WeekNumber { get; set; }

        public int PeriodNumber { get; set; }
        public bool Draft { get; set; }

        public DateOnly StartDateWeek { get; set; }

        public DateOnly EndDateWeek { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<HalfDayPlanningResponse>? HalfDayPlanning { get; set; } = new List<HalfDayPlanningResponse>();

        public virtual ICollection<SignedContractResponse> SignedContracts { get; set; } = new List<SignedContractResponse>();

    }
}
