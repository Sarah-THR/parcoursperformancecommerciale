using EcoleDeLaPerformance.API.Host.Endpoints.Evaluations;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Evaluations
{
    public class InsertEvaluationSummary : Summary<InsertEvaluationEndpoint>
    {
        public InsertEvaluationSummary()
        {
            Summary = "Création d'une evaluation.";
            Description = "Création d'une evaluation.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
