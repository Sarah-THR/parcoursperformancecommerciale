namespace EcoleDeLaPerformance.Ui.Models
{
    public class TaskPlanning
    {
        public int TaskId { get; set; }

        public string Titled { get; set; } = null!;
        public string Identifier { get; set; }

        public virtual ICollection<HalfDayPlanning> HalfDayPlannings { get; set; } = new List<HalfDayPlanning>();
    }
}
