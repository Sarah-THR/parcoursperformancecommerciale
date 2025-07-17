using EcoleDeLaPerformance.API.Host.Endpoints.Evaluations;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Evaluations
{
    public class UpdateEvaluationSummary : Summary<UpdateEvaluationEndpoint>
    {
        public UpdateEvaluationSummary()
        {
            Summary = "Modification d'une evaluation.";
            Description = "Modification d'une evaluation.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
