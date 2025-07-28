using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly IConfiguration _configuration;

        public PlanningService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Planning?>> GetPlanningByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/plannings?startDateWeek={startDateWeek}&endDateWeek={endDateWeek}&userId={userId}");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Planning?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des plannings : {await response.Content.ReadAsStringAsync()}"),
            };
        }
        public async Task<Planning?> InsertPlanningAsync(Planning planning)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(planning), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/plannings", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<Planning?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "Le planning a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout du planning : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task DeletePlanningAsync(int Id)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/plannings/{Id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression du planning : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task UpdatePlanningAsync(Planning planning)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(planning), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/plannings", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le planning à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le planning avec l'id {planning.Id} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification du planning : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }
    }
}
