using EcoleDeLaPerformance.API.Host.Endpoints.Users;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Users
{
    public class GetUsersSummary : Summary<GetUsersEndpoint>
    {
        public GetUsersSummary()
        {
            Summary = "Récupération de tous les utilisateurs.";
            Description = "Récupération de tous les utilisateurs.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
