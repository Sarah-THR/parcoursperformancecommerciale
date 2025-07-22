using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IConfiguration _configuration;

        public EvaluationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Evaluation?>> GetEvaluationsAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/evaluations");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Evaluation?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des evaluations : {await response.Content.ReadAsStringAsync()}"),
            };
        }
        public async Task<Evaluation?> InsertEvaluationAsync(Evaluation evaluation)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(evaluation), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/evaluations", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<Evaluation?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "L'evaluation a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout de l'evaluation : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task DeleteEvaluationAsync(int Id)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/evaluations/{Id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression de l'evaluation : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task UpdateEvaluationAsync(Evaluation evaluation)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(evaluation), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/evaluations", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("L'evaluation à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"L'evaluation avec l'id {evaluation.Id} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification de l'evaluation : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }
    }
}
