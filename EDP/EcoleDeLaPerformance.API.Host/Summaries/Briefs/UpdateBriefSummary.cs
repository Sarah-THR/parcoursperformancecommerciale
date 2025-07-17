using EcoleDeLaPerformance.API.Host.Endpoints.Briefs;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Briefs
{
    public class UpdateBriefSummary : Summary<UpdateBriefEndPoint>
    {
        public UpdateBriefSummary()
        {
            Summary = "Modification d'un brief.";
            Description = "Modification d'un brief.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
