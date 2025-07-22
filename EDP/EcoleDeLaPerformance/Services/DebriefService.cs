using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class DebriefService: IDebriefService
    {
        private readonly IConfiguration _configuration;
        public DebriefService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Debrief?>> GetDebriefByUserAsync(DateTime startDateWeek, DateTime endDateWeek, int userId)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/debriefs?UserId={userId}&StartDateWeek={startDateWeek}&EndDateWeek={endDateWeek}");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Debrief>>(),
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("Les paramètres sont obligatoires."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des debriefs : {await response.Content.ReadAsStringAsync()}"),
            };
        }
        public async Task<Debrief?> InsertDebriefAsync(Debrief debrief)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(debrief), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/debriefs", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<Debrief?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "Le debrief a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout du debrief : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task DeleteDebriefAsync(int Id)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/debriefs/{Id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression du debrief : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task UpdateDebriefAsync(Debrief debrief)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(debrief), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/debriefs", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le debrief à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le debrief avec l'id {debrief.Id} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification du debrief : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }
    }
}
