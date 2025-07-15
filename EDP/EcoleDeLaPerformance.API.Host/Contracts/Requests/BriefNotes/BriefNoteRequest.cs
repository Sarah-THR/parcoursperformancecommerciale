namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes
{
    public class BriefNoteRequest
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public string? Brief { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
