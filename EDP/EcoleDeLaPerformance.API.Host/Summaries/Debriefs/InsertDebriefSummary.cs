using EcoleDeLaPerformance.API.Host.Endpoints.Debriefs;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Debriefs
{
    public class InsertDebriefSummary : Summary<InsertDebriefEndpoint>
    {
        public InsertDebriefSummary()
        {
            Summary = "Création d'un debrief.";
            Description = "Création d'un debrief.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
