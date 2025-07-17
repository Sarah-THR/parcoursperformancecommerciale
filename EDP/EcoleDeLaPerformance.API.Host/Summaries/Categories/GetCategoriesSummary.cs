using EcoleDeLaPerformance.API.Host.Endpoints.Categories;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Categories
{
    public class GetCategoriesSummary : Summary<GetCategoriesEndpoint>
    {
        public GetCategoriesSummary()
        {
            Summary = "Récupération de toutes les categories.";
            Description = "Récupération de toutes les categories.";
            Response((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
