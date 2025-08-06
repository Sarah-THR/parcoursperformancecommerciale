using System.Text.Json.Serialization;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities
{
    public class FavoritesAgency
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? AgencyName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; } = null!;
    }
}
