using EcoleDeLaPerformance.Ui.Interfaces;
using System.Net;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class DebitAccountService: IDebitAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public DebitAccountService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<int> GetDebitAccountByCommercialNameAsync(string name)
        {
            var response = _httpClient.GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/debitAccount/{name}").Result;

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content.ReadFromJsonAsync<int>().Result,
                HttpStatusCode.BadRequest => throw new Exception("Une erreur est survenue."),
                _ => throw new Exception($"Une erreur est survenue : {response.Content.ReadAsStringAsync().Result}"),
            };
        }

        public async Task<int> GetDebitAccountByPeriodAsync(string name, DateOnly periodFirstDay, DateOnly periodLastDay)
        {
            var response = _httpClient.GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/debitAccount?name={name}&periodFirstDay={periodFirstDay}&periodLastDay={periodLastDay}").Result;

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content.ReadFromJsonAsync<int>().Result,
                HttpStatusCode.BadRequest => throw new Exception("Une erreur est survenue."),
                _ => throw new Exception($"Une erreur est survenue : {response.Content.ReadAsStringAsync().Result}"),
            };
        }
    }
}
