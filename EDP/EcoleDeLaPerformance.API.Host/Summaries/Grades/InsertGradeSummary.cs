using EcoleDeLaPerformance.API.Host.Endpoints.Grades;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Grades
{
    public class InsertGradeSummary : Summary<InsertGradeEndpoint>
    {
        public InsertGradeSummary()
        {
            Summary = "Création d'un grade.";
            Description = "Création d'un grade.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
