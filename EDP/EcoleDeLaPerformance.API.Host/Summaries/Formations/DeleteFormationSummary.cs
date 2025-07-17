using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Formations;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Formations
{
    public class DeleteFormationSummary : Summary<DeleteFormationEndpoint>
    {
        public DeleteFormationSummary()
        {
            Summary = "Suppression d'une formation.";
            Description = "Suppression d'une formation.";
            Response<DebriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucune formation avec cet id n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ Id est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
