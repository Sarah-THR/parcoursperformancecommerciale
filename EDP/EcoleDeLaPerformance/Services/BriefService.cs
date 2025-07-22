using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class BriefService : IBriefService
    {
        private readonly IConfiguration _configuration;
        public BriefService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Brief>> GetBriefByUserId(DateTime startDateWeek, DateTime endDateWeek, int userId)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/briefs?UserId={userId}&StartDateWeek={startDateWeek}&EndDateWeek={endDateWeek}");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Brief>>(),
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("Les paramètres sont obligatoires."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des briefs : {await response.Content.ReadAsStringAsync()}"),
            };
        }

        public async Task<Brief> InsertBriefAsync(Brief brief)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(brief), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/briefs", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<Brief?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "Le brief a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout du brief : {await response.Content.ReadAsStringAsync()}");
        }

        public async System.Threading.Tasks.Task UpdateBriefAsync(Brief brief)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(brief), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/briefs", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le brief à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le brief avec l'id {brief.Id} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification de la brief : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }

        public async System.Threading.Tasks.Task DeleteBriefAsync(int id)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/briefs/{id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression du brief : {await response.Content.ReadAsStringAsync()}");
        }
    }
}
