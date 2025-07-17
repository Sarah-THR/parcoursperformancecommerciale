using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Evaluations;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Evaluations
{
    public class DeleteEvaluationSummary : Summary<DeleteEvaluationEndpoint>
    {
        public DeleteEvaluationSummary()
        {
            Summary = "Suppression d'une evaluation.";
            Description = "Suppression d'une evaluation.";
            Response<DebriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucune evaluation avec cet id n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ Id est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
