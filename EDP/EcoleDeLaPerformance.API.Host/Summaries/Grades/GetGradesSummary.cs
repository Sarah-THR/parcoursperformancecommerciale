using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;
using EcoleDeLaPerformance.API.Host.Endpoints.Grades;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Grades
{
    public class GetGradesSummary : Summary<GetGradesEndpoint>
    {
        public GetGradesSummary()
        {
            Summary = "Récupération des grades.";
            Description = "Récupération des grades.";
            Response<DebriefResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun grade n'a été retrouvé.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
