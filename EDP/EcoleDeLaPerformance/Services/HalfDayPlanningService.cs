using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class HalfDayPlanningService : IHalfDayPlanningService
    {
        private readonly IConfiguration _configuration;

        public HalfDayPlanningService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<HalfDayPlanning?>> GetHalfDayPlanningsByWeekIdAsync(int weekId)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/halfdayplanning/{weekId}");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<HalfDayPlanning?>>(),
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("L'email est obligatoire."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des semaines de l'utilisateur : {await response.Content.ReadAsStringAsync()}"),
            };
        }

        public async Task<HalfDayPlanning> InsertHalfDayPlanningAsync(HalfDayPlanning halfDayPlanning)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(halfDayPlanning), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/halfdayplanning/InsertHalfDayPlanning", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<HalfDayPlanning?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "Le HalfDayPlanning a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout de la note : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task UpdateHalfDayPlanningAsync(HalfDayPlanning halfDayPlanning)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(halfDayPlanning), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/halfdayplanning", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le halfDayPlanning à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le halfDayPlanning avec l'id {halfDayPlanning.HalfDayId} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification du halfDayPlanning : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }

        public async Task DeleteHalfDayPlanningAsync(int halfDayId)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/halfdayplanning/{halfDayId}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression du halfdayplanning : {await response.Content.ReadAsStringAsync()}");
        }
    }
}
