namespace EcoleDeLaPerformance.Ui.Models
{
    public class Week
    {
        public int WeekId { get; set; }

        public int WeekNumber { get; set; }

        public int PeriodNumber { get; set; }

        public DateOnly StartDateWeek { get; set; }

        public DateOnly EndDateWeek { get; set; }

        public int UserId { get; set; }
        public bool Draft { get; set; }

        public virtual ICollection<HalfDayPlanning>? HalfDayPlanning { get; set; } = new List<HalfDayPlanning>();

        public virtual ICollection<SignedContract> SignedContracts { get; set; } = new List<SignedContract>();

        public virtual User User { get; set; } = null!;
    }
}
