using EcoleDeLaPerformance.API.Host.Endpoints.Weeks;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Weeks
{
    public class CreateWeekSummary : Summary<CreateWeekEndpoint>
    {
        public CreateWeekSummary()
        {
            Summary = "Création d'une semaine.";
            Description = "Création d'une semaine.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
