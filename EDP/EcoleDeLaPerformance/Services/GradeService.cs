using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class GradeService : IGradeService
    {
        private readonly IConfiguration _configuration;

        public GradeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Grade?>> GetGradesAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/grades");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Grade?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des grades : {await response.Content.ReadAsStringAsync()}"),
            };
        }
        public async Task<Grade?> InsertGradeAsync(Grade grade)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(grade), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/grades", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<Grade?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "Le grade a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout du grade : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task DeleteGradeAsync(int Id)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/grades/{Id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression du grade : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task UpdateGradeAsync(Grade grade)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(grade), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/grades", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le grade à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le grade avec l'id {grade.Id} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification du grade : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }
    }
}
