using EcoleDeLaPerformance.API.Host.Endpoints.TaskPlanning;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.TaskPlanning
{
    public class GetAllTaskPlanningSummary : Summary<GetAllTaskPlanningEndpoint>
    {
        public GetAllTaskPlanningSummary()
        {
            Summary = "Récupération de toutes les tâches différentes.";
            Description = "Récupération de toutes les tâches différentes.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
