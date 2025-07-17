using EcoleDeLaPerformance.API.Host.Contracts.Responses.Briefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Briefs;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Briefs
{
    public class GetBriefByUserIdSummary : Summary<GetBriefByUserIdEndpoint>
    {
        public GetBriefByUserIdSummary()
        {
            Summary = "Récupération des briefs de l'utilisateur en fonction de son id.";
            Description = "Récupération des briefs de l'utilisateur en fonction de son id.";
            Response<BriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun brief avec cet utilisateur n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ UserId est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}

