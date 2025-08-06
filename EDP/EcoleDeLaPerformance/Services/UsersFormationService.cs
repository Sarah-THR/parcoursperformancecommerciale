using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class UsersFormationService : IUsersFormationService
    {
        private readonly IConfiguration _configuration;

        public UsersFormationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UsersFormation?> InsertUsersFormationAsync(UsersFormation usersFormation)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(usersFormation), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/usersFormations", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<UsersFormation?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "Le UsersFormation a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout du UsersFormation : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task UpdateUsersFormationAsync(UsersFormation usersFormation)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(usersFormation), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/usersFormations", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le UsersFormation à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le UsersFormation {usersFormation} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification du UsersFormation : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }
    }
}
