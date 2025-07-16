namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Document
{
    public class UpdateDocumentRequest
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ContentPath { get; set; } = null!;

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? CategoryId { get; set; }
    }
}
