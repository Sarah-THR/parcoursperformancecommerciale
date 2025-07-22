namespace EcoleDeLaPerformance.Ui.Models;

public partial class Brief
{
    public int Id { get; set; }

    public string SignatureCommitment { get; set; } = null!;

    public string FilesToCheck { get; set; } = null!;

    public string Note { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
