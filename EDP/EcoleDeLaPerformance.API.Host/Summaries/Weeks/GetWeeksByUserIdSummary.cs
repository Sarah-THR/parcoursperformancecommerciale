using EcoleDeLaPerformance.API.Host.Endpoints.Weeks;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Weeks
{
    public class GetWeeksByUserIdSummary : Summary<GetWeeksByUserIdEndpoint>
    {
        public GetWeeksByUserIdSummary()
        {
            Summary = "Récupération des semaines d'un utilisateur par son Id.";
            Description = "Récupération des semaines d'un utilisateur par son Id.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
