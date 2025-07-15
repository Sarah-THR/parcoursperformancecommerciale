using EcoleDeLaPerformance.API.Host.Endpoints.Users;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Users
{
    public class GetUserByIdSummary : Summary<GetUserByIdEndpoint>
    {
        public GetUserByIdSummary()
        {
            Summary = "Récupération de l'utilisateurs par son Id.";
            Description = "Récupération de l'utilisateurs par son Id.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
