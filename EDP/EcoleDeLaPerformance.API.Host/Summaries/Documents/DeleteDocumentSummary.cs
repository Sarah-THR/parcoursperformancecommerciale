using EcoleDeLaPerformance.API.Host.Endpoints.Documents;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Documents
{
    public class DeleteDocumentSummary : Summary<DeleteDocumentEndpoint>
    {
        public DeleteDocumentSummary()
        {
            Summary = "Suppression d'un document.";
            Description = "Suppression d'un document.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
