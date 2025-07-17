namespace EcoleDeLaPerformance.API.Host.Contracts.Requests.UsersFormations
{
    public class UpdateUsersFormationRequest
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
    }
}
