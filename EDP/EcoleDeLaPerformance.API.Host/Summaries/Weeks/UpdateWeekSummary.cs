using EcoleDeLaPerformance.API.Host.Endpoints.Weeks;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Weeks
{
    public class UpdateWeekSummary : Summary<UpdateWeekEndPoint>
    {
        public UpdateWeekSummary()
        {
            Summary = "Modification d'une semaine.";
            Description = "Modification d'une semaine.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
