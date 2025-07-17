using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Documents;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Evaluations;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Formations;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Statuses;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;

namespace EcoleDeLaPerformance.API.Host.Contracts.Responses.UsersFormations
{
    public class UsersFormationResponse
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

        public virtual DocumentResponse? Document { get; set; }

        public virtual EvaluationResponse? Evaluation { get; set; }

        public virtual FormationResponse Formation { get; set; } = null!;

        public virtual StatusResponse? Status { get; set; }
    }
}
