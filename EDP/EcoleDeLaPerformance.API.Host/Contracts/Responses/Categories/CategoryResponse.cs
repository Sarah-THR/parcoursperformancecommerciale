using EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Categories
{
    public class CategoryResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<DocumentResponse> Documents { get; set; } = new List<DocumentResponse>();
    }
}
