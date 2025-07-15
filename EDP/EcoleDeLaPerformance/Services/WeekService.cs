using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class WeekService : IWeekService
    {
        private readonly IConfiguration _configuration;

        public WeekService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Week?>> GetWeeksByUserIdAsync(int userId)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/weeks/{userId}");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Week?>>(),
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("L'email est obligatoire."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des semaines de l'utilisateur : {await response.Content.ReadAsStringAsync()}"),
            };
        }

        public async Task<List<Week?>> GetWeeksByIdAsync(int weekId)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/weeks/{weekId}");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Week?>>(),
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("L'id est obligatoire."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération de la semaine via son id : {await response.Content.ReadAsStringAsync()}"),
            };
        }

        public async Task<Week> CreateWeekAsync(Week week)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(week), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/weeks", httpContent);

            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<Week?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "La semaine est obligatoire." :
                $"Une erreur est survenue lors de l'ajout de la semaine : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task UpdateWeekAsync(Week week)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(week), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/weeks", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("La semaine à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"La semaine avec l'id {week.WeekId} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification de la semaine : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }
    }
}
