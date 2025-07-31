using EcoleDeLaPerformance.Ui._Helper;
using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System.DirectoryServices;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenAcquisition _tokenAcquisitionService;
        private readonly CRMService _crmService;

        public UserService(IConfiguration configuration, IHttpClientFactory httpClientFactory, ITokenAcquisition tokenAcquisitionService, CRMService crmService)
        {
            _configuration = configuration;
            _crmService = crmService;
            _tokenAcquisitionService = tokenAcquisitionService;
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<List<User?>> GetUsersAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<User?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des Users : {await response.Content.ReadAsStringAsync()}"),
            };
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var response = _httpClient.GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users/{email}").Result;

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content.ReadFromJsonAsync<User>().Result,
                HttpStatusCode.BadRequest => throw new Exception("Une erreur est survenue."),
                _ => throw new Exception($"Une erreur est survenue : {response.Content.ReadAsStringAsync().Result}"),
            };
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            var response = _httpClient.GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users/{id}").Result;

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content.ReadFromJsonAsync<User>().Result,
                HttpStatusCode.BadRequest => throw new Exception("Une erreur est survenue."),
                _ => throw new Exception($"Une erreur est survenue : {response.Content.ReadAsStringAsync().Result}"),
            };
        }
        public async Task<User?> InsertUserAsync(User user)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(user), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users", httpContent);


            return (response.StatusCode == HttpStatusCode.OK) ? (await response.Content.ReadFromJsonAsync<User?>())! :
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                "L'user a crée est obligatoire." :
                $"Une erreur est survenue lors de l'ajout du user : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task DeleteUserAsync(int Id)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users/{Id}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression du user : {await response.Content.ReadAsStringAsync()}");
        }
        public async System.Threading.Tasks.Task UpdateUserAsync(User user)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(user), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users", httpContent);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.BadRequest:
                    throw new Exception("Le user à modifier est obligatoire.");

                case HttpStatusCode.NotFound:
                    throw new Exception($"Le user avec l'id {user.Id} n'existe pas.");

                default:
                    throw new Exception($"Une erreur est survenue lors de modification du user : {await response.Content.ReadAsStringAsync()} avec le status code : {response.StatusCode}.");
            }
        }

        public User? GetUserAAD(string email)
        {
            using DirectorySearcher dirsearcher = new(Domain.GetDirectoryEntry(),
                                                          $"(&(objectClass=user)(mail=*{email}*))",
                                                          new string[] { "displayName", "givenName", "mail", "company" });

            var user = dirsearcher.FindOne();
            if (user != null)
            {
                return new User()
                {
                    Name = user.GetPropertyValue("displayName"),
                    Email = user.GetPropertyValue("mail"),
                    Entity = user.GetPropertyValue("company"),
                };
            }
            else
            {
                return new User();
            }
        }

        #region APICRM
        public async Task<decimal> GetUserBonusAsync(string name, DateOnly startDate, DateOnly endDate)
        {
            try
            {
                var apiUrl = _configuration.GetValue<string>("EDPApiUrl");
                var queryString = $"?name={Uri.EscapeDataString(name)}&startDate={startDate}&endDate={endDate}";

                var response = await new HttpClient().GetAsync($"{apiUrl}api/turnover{queryString}");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var turnover = await response.Content.ReadFromJsonAsync<decimal>();
                    return turnover / 12;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception("Le nom de l'étudiant, la date de début et la date de fin sont obligatoires.");
                }
                else
                {
                    throw new Exception($"Une erreur est survenue lors de la prime : {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération de la prime : {ex.Message}");
                throw;
            }
        }

        public async Task<decimal> GetUserTurnoverAsync(string name, DateOnly startDate, DateOnly endDate)
        {
            try
            {
                var apiUrl = _configuration.GetValue<string>("EDPApiUrl");
                var queryString = $"?name={Uri.EscapeDataString(name)}&startDate={startDate}&endDate={endDate}";

                var response = await new HttpClient().GetAsync($"{apiUrl}api/turnover{queryString}");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var turnover = await response.Content.ReadFromJsonAsync<decimal>();
                    return turnover;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception("Le nom de l'étudiant, la date de début et la date de fin sont obligatoires.");
                }
                else
                {
                    throw new Exception($"Une erreur est survenue lors de la prime : {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération de la prime : {ex.Message}");
                throw;
            }
        }
        //public async Task<int> GetNbOpenAccountsAsync(string name)
        //{
        //    try
        //    {
        //        var apiUrl = _configuration.GetValue<string>("EDPApiUrl");
        //        var queryString = $"?name={Uri.EscapeDataString(name)}";

        //        var response = await new HttpClient().GetAsync($"{apiUrl}api/debitAccount{queryString}");

        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            return await response.Content.ReadFromJsonAsync<int>();
        //        }
        //        else if (response.StatusCode == HttpStatusCode.BadRequest)
        //        {
        //            throw new Exception("Le nom de l'étudiant est obligatoire.");
        //        }
        //        else
        //        {
        //            throw new Exception($"Une erreur est survenue lors de la récupération du nombre de compte en prélèvements : {await response.Content.ReadAsStringAsync()}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erreur lors de la récupération du nombre de compte en prélèvements : {ex.Message}");
        //        throw;
        //    }
        //}

        //public int GetNbOpenAccountsByPeriod(string name, DateOnly periodFirstDay, DateOnly periodLastDay)
        //{
        //    try
        //    {
        //        var apiUrl = _configuration.GetValue<string>("EDPApiUrl");
        //        var queryString = $"?name={Uri.EscapeDataString(name)}&periodFirstDay={Uri.EscapeDataString(periodFirstDay.ToString("dd-MM-yyyy"))}&periodLastDay={Uri.EscapeDataString(periodLastDay.ToString("dd-MM-yyyy"))}";

        //        var response = new HttpClient().GetAsync($"{apiUrl}api/debitAccountByPeriod{queryString}").Result;

        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            return response.Content.ReadFromJsonAsync<int>().Result;
        //        }
        //        else if (response.StatusCode == HttpStatusCode.BadRequest)
        //        {
        //            throw new Exception("Le nom de l'étudiant et les dates de début et de fin de période est obligatoire.");
        //        }
        //        else
        //        {
        //            throw new Exception($"Une erreur est survenue lors de la récupération du nombre de compte en prélèvements : {response.Content.ReadAsStringAsync().Result}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erreur lors de la récupération du nombre de compte en prélèvements : {ex.Message}");
        //        return 0;
        //    }
        //}

        //public async Task<decimal> GetUserTurnoverAsync(string email, DateOnly beginningDate, DateOnly endingDate)
        //{
        //    await _crmService.GetCrmTokenAsync();
        //    string pattern = @"^([^@]+)";

        //    Regex regex = new Regex(pattern);
        //    Match match = regex.Match(email);
        //    string domain = match.Groups[1].Value;
        //    var requestData = new
        //    {
        //        DomainName = "XEFI\\" + domain,
        //        BeginningDate = beginningDate,
        //        EndingDate = endingDate
        //    };
        //    try
        //    {
        //        string requestDataJson = System.Text.Json.JsonSerializer.Serialize(requestData);

        //        string response = await _crmService.SendRequestToCRMApiAsync("api/Sales/GetWeeklyByUser", requestDataJson);

        //        dynamic responseObject = System.Text.Json.JsonSerializer.Deserialize<dynamic>(response);

        //        if (responseObject.ValueKind == JsonValueKind.Array)
        //        {
        //            decimal totalAmount = 0;

        //            foreach (JsonElement item in responseObject.EnumerateArray())
        //            {
        //                if (item.TryGetProperty("Amount", out JsonElement amountElement))
        //                {
        //                    if (amountElement.TryGetDecimal(out decimal amount))
        //                    {
        //                        totalAmount += amount;
        //                    }
        //                }
        //            }

        //            return totalAmount;
        //        }
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erreur lors de la récupération du chiffre d'affaires : {ex.Message}");
        //        throw;
        //    }
        //}

        public async Task<int> GetNbAppointmentsAsync(string email, DateOnly beginningDate, DateOnly endingDate)
        {
            await _crmService.GetCrmTokenAsync();
            string pattern = @"^([^@]+)";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(email);
            string domain = match.Groups[1].Value;
            var requestData = new
            {
                DomainName = "XEFI\\" + domain,
                BeginningDate = beginningDate,
                EndingDate = endingDate
            };
            try
            {
                string requestDataJson = System.Text.Json.JsonSerializer.Serialize(requestData);

                string response = await _crmService.SendRequestToCRMApiAsync("api/Appointment/GetNbAppointmentsForUser", requestDataJson);

                if (Int32.Parse(response) != 0)
                {
                    return Int32.Parse(response);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération du chiffre d'affaires : {ex.Message}");
                throw;
            }
        }

        #endregion
    }
}
