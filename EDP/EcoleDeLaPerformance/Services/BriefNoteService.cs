using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class BriefNoteService : IBriefNoteService
    {
        private readonly IConfiguration _configuration;
        public BriefNoteService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<BriefNote>> GetWeekNoteByUserId(DateTime startDateWeek, DateTime endDateWeek, int userId)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/briefnote?UserId={userId}&StartDateWeek={startDateWeek}&EndDateWeek={endDateWeek}");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<BriefNote>>(),
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("Les paramètres sont obligatoires."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des notes : {await response.Content.ReadAsStringAsync()}"),
            };
        }

        public async Task<BriefNote> InsertBriefNoteAsync(BriefNote briefNote)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(briefNote), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/briefnote/InsertBriefNote", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<BriefNote?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "La note a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout de la note : {await response.Content.ReadAsStringAsync()}");
        }

        public async Task UpdateBriefNoteAsync(BriefNote briefNote)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(briefNote), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/briefnote", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("La briefnote à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"La briefnote avec l'id {briefNote.BriefNoteId} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification de la briefnote : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }

        public async Task DeleteBriefNoteAsync(int briefNote)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/briefnote/{briefNote}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression de la briefnote : {await response.Content.ReadAsStringAsync()}");
        }
    }
}
