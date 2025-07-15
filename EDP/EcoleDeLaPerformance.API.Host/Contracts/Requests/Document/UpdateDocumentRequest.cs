namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Document
{
    public class UpdateDocumentRequest
    {
        public int Id { get; set; }

        public string? File { get; set; }

        public string Title { get; set; } = null!;

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? ClassId { get; set; }

    }
}
