namespace EcoleDeLaPerformance.Ui.Models
{
    public class BriefNote
    {
        public int BriefNoteId { get; set; }

        public int TypeNote { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime CreateDate { get; set; }

        public string? TextNote { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
