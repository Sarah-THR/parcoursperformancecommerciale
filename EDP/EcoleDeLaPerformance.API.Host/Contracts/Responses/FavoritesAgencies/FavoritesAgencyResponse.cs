namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.FavoritesAgencies
{
    public class FavoritesAgencyResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? AgencyName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
