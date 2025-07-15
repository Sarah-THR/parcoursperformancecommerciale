using EcoleDeLaPerformance.API.Host.Contracts.Responses.BriefNotes;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.Users
{
    public class SupervisorNavigationResponse
    {
        public int UserId { get; set; }

        public string EmailAdress { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Entity { get; set; } = null!;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public byte[]? ProfilePicture { get; set; }

        public string Role { get; set; } = null!;

        public int Supervisor { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<BriefNoteResponse> BriefNotes { get; set; } = new List<BriefNoteResponse>();

        public virtual ICollection<DocumentResponse> DocumentCreateByNavigations { get; set; } = new List<DocumentResponse>();

        public virtual ICollection<DocumentResponse> DocumentUpdateByNavigations { get; set; } = new List<DocumentResponse>();
    }
}
