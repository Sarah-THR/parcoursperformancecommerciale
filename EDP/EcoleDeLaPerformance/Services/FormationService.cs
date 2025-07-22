using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class FormationService : IFormationService
    {
        private readonly IConfiguration _configuration;

        public FormationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Formation?>> GetFormationsAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/formations");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Formation?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des formations : {await response.Content.ReadAsStringAsync()}"),
            };
        }
        public async Task<Formation?> InsertFormationAsync(Formation formation)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(formation), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/formations", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<Formation?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "La formation a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout de la formation : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task DeleteFormationAsync(int Id)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/formations/{Id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression de la formation : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task UpdateFormationAsync(Formation formation)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(formation), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/formations", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("La formation à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"La formation avec l'id {formation.Id} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification de la formation : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }
    }
}
