namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.HalfDayPlannings
{
    public class HalfDayPlanningRequest
    {

        public int HalfDayId { get; set; }
        public bool? HalfDayTime { get; set; }
        public DateTime HalfDayDate { get; set; }

        public int WeekId { get; set; }

        public int TaskId { get; set; }
    }
}
