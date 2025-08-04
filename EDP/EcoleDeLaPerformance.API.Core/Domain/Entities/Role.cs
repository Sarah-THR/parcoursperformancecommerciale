namespace EcoleDeLaPerformance.API.Core.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
