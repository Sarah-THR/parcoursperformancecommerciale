namespace EcoleDeLaPerformance.Ui.Models
{
    public class Document
    {
        public int DocumentId { get; set; }

        public string Pdffile { get; set; } = null!;

        public string Title { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? CreateBy { get; set; }

        public int? UpdateBy { get; set; }

        public int ClassId { get; set; }

        public virtual Class Class { get; set; } = null!;

        public virtual User? CreateByNavigation { get; set; }

        public virtual User UpdateByNavigation { get; set; } = null!;
    }
}
