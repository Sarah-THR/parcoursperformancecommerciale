using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Debriefs;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Debriefs
{
    public class GetDebriefByUserIdSummary : Summary<GetDebriefByUserIdEndpoint>
    {
        public GetDebriefByUserIdSummary()
        {
            Summary = "Récupération des debriefs de l'utilisateur en fonction de son id.";
            Description = "Récupération des debriefs de l'utilisateur en fonction de son id.";
            Response<DebriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun debrief avec cet utilisateur n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ UserId est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
