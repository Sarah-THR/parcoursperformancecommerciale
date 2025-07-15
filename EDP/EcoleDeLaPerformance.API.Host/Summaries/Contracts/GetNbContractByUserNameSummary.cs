using EcoleDeLaPerformance.API.Host.Contracts.Responses.Contracts;
using EcoleDeLaPerformance.API.Host.Endpoints.Contracts;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Contracts
{
    public class GetNbContractByUserNameSummary : Summary<GetNbContractByUserNameEndpoint>
    {
        public GetNbContractByUserNameSummary()
        {
            Summary = "Récupération du nombre de contrats de l'utilisateur.";
            Description = "Récupération du nombre de contrats de l'utilisateur.";
            Response<int>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun contrat pour cet utilisateur n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ nom d'utilisateur est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
