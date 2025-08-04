namespace EcoleDeLaPerformance.Ui.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
