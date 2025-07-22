namespace EcoleDeLaPerformance.Ui.Models;

public partial class UsersFormation
{
    public int UserId { get; set; }

    public int FormationId { get; set; }

    public int? StatusId { get; set; }

    public int? EvaluationId { get; set; }

    public bool IsValidated { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? DocumentId { get; set; }

    public virtual Document? Document { get; set; }

    public virtual Evaluation? Evaluation { get; set; }

    public virtual Formation Formation { get; set; } = null!;

    public virtual Status? Status { get; set; }

    public virtual User User { get; set; } = null!;
}
