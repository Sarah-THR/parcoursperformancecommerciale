using EcoleDeLaPerformance.API.Host.Endpoints.HalfDayPlannings;
using EcoleDeLaPerformance.API.Host.Endpoints.Users;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.HalfDayPlannings
{
    public class GetHalfDayPlanningByWeekIdSummary : Summary<GetHalfDayPlanningByWeekIdEndpoint>
    {
        public GetHalfDayPlanningByWeekIdSummary()
        {
            Summary = "Récupération du planning par l'Id de la semaine.";
            Description = "Récupération du planning par l'Id de la semaine.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
