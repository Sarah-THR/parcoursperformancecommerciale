using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Grades;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Grades
{
    public class DeleteGradeSummary : Summary<DeleteGradeEndpoint>
    {
        public DeleteGradeSummary()
        {
            Summary = "Suppression d'un grade.";
            Description = "Suppression d'un grade.";
            Response<DebriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun grade avec cet id n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ Id est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
