using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Host.Endpoints.BriefNote;
using EcoleDeLaPerformance.API.Host.Endpoints.Users;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.BriefNote
{
    public class GetWeekNoteByUserIdSummary : Summary<GetWeekNoteByUserIdByUserEndpoint>
    {
        public GetWeekNoteByUserIdSummary()
        {
            Summary = "Récupération des BriefNote de l'utilisateur en fonction de son id.";
            Description = "Récupération des BriefNote de l'utilisateur en fonction de son id.";
            Response<UserResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucune BriefNotes avec cet utilisateur n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ UserId est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}

