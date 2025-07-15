using EcoleDeLaPerformance.API.Host.Endpoints.Documents;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Documents
{
    public class GetDocumentsSummary : Summary<GetDocumentsEndpoint>
    {
        public GetDocumentsSummary()
        {
            Summary = "Récupération de tous les documents.";
            Description = "Récupération de tous les documents.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
