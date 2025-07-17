using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Debriefs;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Debriefs
{
    public class DeleteDebriefSummary : Summary<DeleteDebriefEndpoint>
    {
        public DeleteDebriefSummary()
        {
            Summary = "Suppression d'un debrief.";
            Description = "Suppression d'un debrief.";
            Response<DebriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun debrief avec cet id n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ Id est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
