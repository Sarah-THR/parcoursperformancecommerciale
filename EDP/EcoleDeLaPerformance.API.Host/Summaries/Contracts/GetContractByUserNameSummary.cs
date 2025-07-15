using EcoleDeLaPerformance.API.Host.Contracts.Responses.Contracts;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Host.Endpoints.Contracts;
using EcoleDeLaPerformance.API.Host.Endpoints.Users;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Contracts
{
    public class GetContractByUserNameSummary : Summary<GetContractByUserNameEndpoint>
    {
        public GetContractByUserNameSummary()
        {
            Summary = "Récupération des contrats SMS de l'utilisateur.";
            Description = "Récupération des contrats SMS de l'utilisateur.";
            Response<ContractSmsResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun contrat pour cet utilisateur n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ nom d'utilisateur est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
