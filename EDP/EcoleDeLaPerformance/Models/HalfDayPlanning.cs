namespace EcoleDeLaPerformance.Ui.Models
{
    public class HalfDayPlanning
    {
        public int HalfDayId { get; set; }
        public bool? HalfDayTime { get; set; }
        public DateTime HalfDayDate { get; set; }

        public int WeekId { get; set; }

        public int TaskId { get; set; }

        public virtual TaskPlanning Task { get; set; } = null!;

        public virtual Week Week { get; set; } = null!;
    }
}
