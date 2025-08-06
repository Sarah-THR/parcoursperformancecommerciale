namespace EcoleDeLaPerformance.Ui.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? ProfilePicturePath { get; set; }

    public string? Entity { get; set; }

    public DateOnly? StartFollowUp { get; set; }

    public int? SupervisorId { get; set; }

    public int? DirectorId { get; set; }

    public int? RoleId { get; set; }

    public bool IsFirstConnection { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? GradeId { get; set; }

    public virtual ICollection<Brief> Briefs { get; set; } = new List<Brief>();

    public virtual ICollection<Debrief> Debriefs { get; set; } = new List<Debrief>();

    public virtual User? Director { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual Grade? Grade { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<User> InverseDirector { get; set; } = new List<User>();

    public virtual ICollection<User> InverseSupervisor { get; set; } = new List<User>();

    public virtual ICollection<Planning> Plannings { get; set; } = new List<Planning>();

    public virtual User? Supervisor { get; set; }

    public virtual ICollection<UsersFormation> UsersFormations { get; set; } = new List<UsersFormation>();
}
