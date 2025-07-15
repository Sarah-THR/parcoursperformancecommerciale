using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Host.Endpoints.HalfDayPlannings;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.HalfDayPlannings
{
    public class DeleteHalfDayPlanningSummary : Summary<DeleteHalfDayPlanningEndpoint>
    {
        public DeleteHalfDayPlanningSummary()
        {
            Summary = "Suppression d'un HalfDayPlanning en fonction de son Id.";
            Description = "Suppression d'un HalfDayPlanning en fonction de son Id.";
            Response<UserResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucune HalfDayPlanning avec cet id n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ HalfDayPlanningId est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
