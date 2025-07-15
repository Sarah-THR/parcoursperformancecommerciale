using EcoleDeLaPerformance.API.Host.Endpoints.Classes;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Classes
{
    public class GetClassesSummary : Summary<GetClassesEndpoint>
    {
        public GetClassesSummary()
        {
            Summary = "Récupération de tous les cours.";
            Description = "Récupération de tous les cours.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
