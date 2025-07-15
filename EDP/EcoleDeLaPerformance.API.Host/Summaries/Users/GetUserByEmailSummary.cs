using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using EcoleDeLaPerformance.API.Host.Endpoints.Users;
using FastEndpoints;
using System.Net;

namespace EcoleDeLaPerformance.API.Host.Summaries.Users
{
    public class GetUserByEmailSummary : Summary<GetUserByEmailEndpoint>
    {
        public GetUserByEmailSummary()
        {
            Summary = "Récupération d'un utilisateur par email.";
            Description = "Récupération d'un utilisateur par email.";
            Response<UserResponse>((int)HttpStatusCode.OK, "Succès.");
            Response((int)HttpStatusCode.NoContent, "Aucun utilisateur avec cet email n'a été retrouvé.");
            Response((int)HttpStatusCode.BadRequest, "Le champ email est obligatoire.");
            Response((int)HttpStatusCode.Unauthorized, "Vous n'êtes pas autorisé à accéder à cette ressource.");
            Response((int)HttpStatusCode.InternalServerError, "Une erreur est survenue lors du traitement.");
        }
    }
}
