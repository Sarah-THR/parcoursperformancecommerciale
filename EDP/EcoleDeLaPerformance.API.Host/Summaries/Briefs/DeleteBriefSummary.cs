using EcoleDeLaPerformance.API.Host.Contracts.Responses.Briefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Briefs;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Briefs
{
    public class DeleteBriefSummary : Summary<DeleteBriefEndPoint>
    {
        public DeleteBriefSummary()
        {
            Summary = "Suppression d'un brief.";
            Description = "Suppression d'un brief.";
            Response<BriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun brief avec cet id n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ Id est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
