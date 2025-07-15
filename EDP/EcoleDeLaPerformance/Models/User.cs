namespace EcoleDeLaPerformance.Ui.Models
{
    public class User
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

        public int? Supervisor { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<BriefNote>? BriefNotes { get; set; } = new List<BriefNote>();

        public virtual ICollection<Document>? DocumentCreateByNavigations { get; set; } = new List<Document>();

        public virtual ICollection<Document>? DocumentUpdateByNavigations { get; set; } = new List<Document>();

        public virtual ICollection<User>? InverseSupervisorNavigation { get; set; } = new List<User>();

        public virtual User? SupervisorNavigation { get; set; } = null!;

        public virtual ICollection<Week>? Weeks { get; set; } = new List<Week>();
    }
}
