using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Host.Endpoints.Turnover;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Turnover
{
    public class GetTurnoverByStudentNameSummary : Summary<GetTurnoverByStudentNameEndpoint>
    {
        public GetTurnoverByStudentNameSummary()
        {
            Summary = "Récupération du chiffre d'affaire de l'étudiant";
            Description = "Récupération du chiffre d'affaire de l'étudiant";
            Response<UserResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun chiffre d'affaire pour cet étudiant n'a été trouvé.");
            Response((int)HttpStatusCode.BadRequest, "Remplir les champs obligatoires.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
