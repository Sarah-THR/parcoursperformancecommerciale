using EcoleDeLaPerformance.API.Host.Endpoints.Debriefs;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Debriefs
{
    public class UpdateDebriefSummary : Summary<UpdateDebriefEndpoint>
    {
        public UpdateDebriefSummary()
        {
            Summary = "Modification d'un debrief.";
            Description = "Modification d'un debrief.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
