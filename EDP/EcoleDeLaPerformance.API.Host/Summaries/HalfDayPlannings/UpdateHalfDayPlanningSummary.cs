using EcoleDeLaPerformance.API.Host.Endpoints.HalfDayPlannings;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.HalfDayPlannings
{
    public class UpdateHalfDayPlanningSummary : Summary<UpdateHalfDayPlanningEndpoint>
    {
        public UpdateHalfDayPlanningSummary()
        {
            Summary = "Modification d'un HalfDayPlanning.";
            Description = "Modification d'un HalfDayPlanning.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
