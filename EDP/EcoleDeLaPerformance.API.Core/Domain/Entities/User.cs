using System;
using System.Collections.Generic;

namespace EcoleDeLaPerformance.API.Core.Domain.Entities;

public partial class User
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? ProfilePicturePath { get; set; }

    public string? Entity { get; set; }

    public DateOnly? StartFollowUp { get; set; }

    public DateOnly? EndFollowUp { get; set; }

    public long? SupervisorId { get; set; }

    public long? DirectorId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public long? GradeId { get; set; }

    public virtual ICollection<Brief> Briefs { get; set; } = new List<Brief>();

    public virtual ICollection<Debrief> Debriefs { get; set; } = new List<Debrief>();

    public virtual User? Director { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual Grade? Grade { get; set; }

    public virtual ICollection<User> InverseDirector { get; set; } = new List<User>();

    public virtual ICollection<User> InverseSupervisor { get; set; } = new List<User>();

    public virtual ICollection<Planning> Plannings { get; set; } = new List<Planning>();

    public virtual User? Supervisor { get; set; }

    public virtual ICollection<UsersFormation> UsersFormations { get; set; } = new List<UsersFormation>();
}
