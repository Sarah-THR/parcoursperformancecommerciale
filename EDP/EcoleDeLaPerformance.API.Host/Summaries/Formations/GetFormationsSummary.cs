using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Formations;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Formations
{
    public class GetFormationsSummary : Summary<GetFormationsEndpoint>
    {
        public GetFormationsSummary()
        {
            Summary = "Récupération des formations.";
            Description = "Récupération des formations.";
            Response<DebriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucune formation n'a été retrouvé.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
