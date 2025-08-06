namespace EcoleDeLaPerformance.Ui.Models
{
    public class FavoritesAgency
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? AgencyName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
