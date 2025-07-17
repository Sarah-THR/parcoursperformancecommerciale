using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Evaluations;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Evaluations
{
    public class GetEvaluationsSummary : Summary<GetEvaluationsEndpoint>
    {
        public GetEvaluationsSummary()
        {
            Summary = "Récupération des evaluations.";
            Description = "Récupération des evaluations.";
            Response<DebriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucune evaluation n'a été retrouvé.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
