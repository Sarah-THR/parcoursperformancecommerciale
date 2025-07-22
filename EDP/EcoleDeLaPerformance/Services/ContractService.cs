using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models.BI;
using System.Net;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class ContractService : IContractService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public ContractService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public List<EcolePerformanceSm?> GetContractsByUserName(string commercial)
        {
            var response = _httpClient.GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/contracts/{commercial}").Result;

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content.ReadFromJsonAsync<List<EcolePerformanceSm?>>().Result,
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("Une erreur est survenue."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des contrats de l'utilisateur : {response.Content.ReadAsStringAsync().Result}"),
            };
        }

        public List<EcolePerformanceSm?> GetContractsByPeriod(string commercial, DateOnly firstDay, DateOnly lastDay)
        {
            var contracts = GetContractsByUserName(commercial);
            return contracts?.Where(x => x.DateSignature >= firstDay && x.DateSignature <= lastDay).ToList();
        }

        public int GetNbContractsByUser(string commercial, DateOnly startDate, DateOnly endDate)
        {
            var response = _httpClient.GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/contracts/{commercial}/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}").Result;

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content.ReadFromJsonAsync<int>().Result,
                HttpStatusCode.NoContent => 0,
                HttpStatusCode.BadRequest => throw new Exception("Une erreur est survenue."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération du nombre de contrats de l'utilisateur : {response.Content.ReadAsStringAsync().Result}"),
            };
        }
        
        public int GetNbContractsSaleByUser(string commercial, DateOnly startDate, DateOnly endDate)
        {
            var response = _httpClient.GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/contractssale/{commercial}").Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var contracts = response.Content.ReadFromJsonAsync<List<VenteOneShot>>().Result;

                var filteredContracts = contracts.Where(c => c.do_date >= startDate && c.do_date <= endDate).ToList();

                return filteredContracts.Count;
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return 0;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new Exception("Une erreur est survenue.");
            }
            else
            {
                throw new Exception($"Une erreur est survenue lors de la récupération du nombre de contrats de l'utilisateur : {response.Content.ReadAsStringAsync().Result}");
            }
        }


        public int GetNbContractsNexleaseByUser(string commercial, DateOnly startDate, DateOnly endDate)
        {
            var response = _httpClient.GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/contractsnexlease/{commercial}").Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var contracts = response.Content.ReadFromJsonAsync<List<NexleaseContract>>().Result;

                var filteredContracts = contracts.Where(c => c.do_date >= startDate && c.do_date <= endDate).ToList();

                return filteredContracts.Count;
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return 0;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new Exception("Une erreur est survenue.");
            }
            else
            {
                throw new Exception($"Une erreur est survenue lors de la récupération du nombre de contrats de l'utilisateur : {response.Content.ReadAsStringAsync().Result}");
            }
        }
    }
}
