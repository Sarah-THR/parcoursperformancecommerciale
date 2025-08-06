namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.FavoritesAgencies
{
    public class FavoritesAgencyRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? AgencyName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
