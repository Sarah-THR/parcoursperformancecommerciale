namespace EcoleDeLaPerformance.Ui.Models
{
    public class Class
    {
        public int ClassId { get; set; }

        public string ClassName { get; set; } = null!;

        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
