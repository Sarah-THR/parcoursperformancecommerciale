using EcoleDeLaPerformance.API.Host.Endpoints.Formations;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Formations
{
    public class UpdateFormationSummary : Summary<UpdateFormationEndpoint>
    {
        public UpdateFormationSummary()
        {
            Summary = "Modification d'une formation.";
            Description = "Modification d'une formation.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
