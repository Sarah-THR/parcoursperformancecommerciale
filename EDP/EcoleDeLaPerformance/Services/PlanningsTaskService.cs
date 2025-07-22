using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class PlanningsTaskService : IPlanningsTaskService
    {
        private readonly IConfiguration _configuration;

        public PlanningsTaskService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PlanningsTask?> InsertPlanningsTaskAsync(PlanningsTask planningsTask)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(planningsTask), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/planningsTasks", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<PlanningsTask?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "Le planning a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout du planningsTask : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task UpdatePlanningsTaskAsync(PlanningsTask planningsTask)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(planningsTask), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/planningsTasks", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le planningsTask à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le planningsTask {planningsTask} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification du planningsTask : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }
    }
}
