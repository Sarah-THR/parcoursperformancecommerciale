using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Host.Endpoints.BriefNote;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.BriefNote
{
    public class DeleteBriefNoteSummary : Summary<DeleteBriefEndPoint>
    {
        public DeleteBriefNoteSummary()
        {
            Summary = "Suppression d'une BriefNote en fonction de son Id.";
            Description = "Suppression d'une BriefNote en fonction de son Id.";
            Response<UserResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucune BriefNote avec cet id n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ BriefNoteId est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
