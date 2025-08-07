namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.Formations
{
    public class FormationRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? GradeId { get; set; }

        public int? RoleId { get; set; }

    }
}
