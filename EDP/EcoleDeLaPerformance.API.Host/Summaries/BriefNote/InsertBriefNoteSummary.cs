using EcoleDeLaPerformance.API.Host.Endpoints.BriefNote;
using EcoleDeLaPerformance.API.Host.Endpoints.Users;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.BriefNote
{
    public class InsertBriefNoteSummary : Summary<InsertBriefNoteEndpoint>
    {
        public InsertBriefNoteSummary()
        {
            Summary = "Création d'une BriefNote.";
            Description = "Création d'une BriefNote.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
