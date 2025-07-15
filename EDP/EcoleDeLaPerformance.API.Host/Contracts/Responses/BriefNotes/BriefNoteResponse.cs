using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.BriefNotes
{
    public class BriefNoteResponse
    {
        public int BriefNoteId { get; set; }

        public int TypeNote { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime CreateDate { get; set; }

        public string? TextNote { get; set; }

        public int UserId { get; set; }

        public virtual UserResponse User { get; set; } = null!;
    }
}
