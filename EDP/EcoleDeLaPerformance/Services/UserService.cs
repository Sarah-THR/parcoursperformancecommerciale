using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.Identity.Web;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using EcoleDeLaPerformance.Ui._Helper;
using System.DirectoryServices;
using EcoleDeLaPerformance.Ui.Helper;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IWeekService _weekService;
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenAcquisition _tokenAcquisitionService;
        private readonly CRMService _crmService;

        public UserService(IConfiguration configuration, IWeekService weekService, IHttpClientFactory httpClientFactory, ITokenAcquisition tokenAcquisitionService, CRMService crmService)
        {
            _configuration = configuration;
            _weekService = weekService;
            _crmService = crmService;
            _tokenAcquisitionService = tokenAcquisitionService;
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(user), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PostAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users", httpContent);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var createdUser = await response.Content.ReadFromJsonAsync<User?>();
                if (createdUser.Role == "Student")
                {
                    await CreateWeeksForUserAsync(createdUser);
                }
                return createdUser!;
            }
            else
            {
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                    "L'utilisateur est obligatoire." :
                    $"Une erreur est survenue lors de l'ajout de l'utilisateur : {await response.Content.ReadAsStringAsync()}");
            }
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users/{email}");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<User?>(),
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("L'email est obligatoire."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération de l'utilisateur : {await response.Content.ReadAsStringAsync()}"),
            };
        }

        public async Task<List<User?>> GetUsersAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users");

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var users = await response.Content.ReadFromJsonAsync<List<User>>();
                    if (users != null)
                    {
                        return users.Where(x => x.IsActive == true).ToList();
                    }
                    else
                    {
                        throw new Exception("La réponse de l'API ne contient aucun utilisateur.");
                    }
                case HttpStatusCode.BadRequest:
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Une erreur est survenue lors de la récupération des utilisateurs : {errorMessage}");
                default:
                    throw new Exception($"La requête a retourné un code d'état HTTP inattendu : {response.StatusCode}");
            }
        }

        public async Task<List<User?>> GetDeletedUsersAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users");

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var users = await response.Content.ReadFromJsonAsync<List<User>>();
                    if (users != null)
                    {
                        return users.Where(x => x.IsActive == false).ToList();
                    }
                    else
                    {
                        throw new Exception("La réponse de l'API ne contient aucun utilisateur.");
                    }
                case HttpStatusCode.BadRequest:
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Une erreur est survenue lors de la récupération des utilisateurs : {errorMessage}");
                default:
                    throw new Exception($"La requête a retourné un code d'état HTTP inattendu : {response.StatusCode}");
            }
        }

        public async Task<List<User?>> GetStudentsAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users");

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var users = await response.Content.ReadFromJsonAsync<List<User>>();
                    if (users != null)
                    {
                        return users.Where(x => x.Role == "Student" && x.IsActive == true).ToList();
                    }
                    else
                    {
                        throw new Exception("La réponse de l'API ne contient aucun utilisateur.");
                    }
                case HttpStatusCode.BadRequest:
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Une erreur est survenue lors de la récupération des utilisateurs : {errorMessage}");
                default:
                    throw new Exception($"La requête a retourné un code d'état HTTP inattendu : {response.StatusCode}");
            }
        }

        public async Task CreateWeeksForUserAsync(User user)
        {
            var weeks = await _weekService.GetWeeksByUserIdAsync(user.UserId);

            var startDate = user.StartDate.Value;
            int daysUntilPreviousMonday = ((int)startDate.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            var adjustedStartDate = startDate.AddDays(-daysUntilPreviousMonday);

            if (weeks == null)
            {
                for (int i = 0; i < 24; i++)
                {
                    var weekStartDate = adjustedStartDate.AddDays(i * 7);
                    var weekEndDate = weekStartDate.AddDays(7);

                    var weekToCreate = new Week
                    {
                        WeekNumber = i + 1,
                        StartDateWeek = DateOnly.FromDateTime(weekStartDate),
                        EndDateWeek = DateOnly.FromDateTime(weekEndDate),
                        UserId = user.UserId,
                        PeriodNumber = (i / 8) + 1
                    };
                    await _weekService.CreateWeekAsync(weekToCreate);
                }
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            using HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(user), new MediaTypeHeaderValue("application/json"));
            var response = await new HttpClient().PutAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users", httpContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var updatedUser = await response.Content.ReadFromJsonAsync<User?>();
                return updatedUser!;
            }
            else
            {
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                    "L'utilisateur est obligatoire." :
                    $"Une erreur est survenue lors de l'update de l'utilisateur : {await response.Content.ReadAsStringAsync()}");
            }
        }

        public async Task<List<User?>> GetAllApprenticesBySupervisorId(int supervisorId)
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var users = await response.Content.ReadFromJsonAsync<List<User?>>();
                return users.Where(x => x.Supervisor == supervisorId && x.IsActive == true).ToList();
            }
            else
            {
                throw new Exception(response.StatusCode == HttpStatusCode.BadRequest ?
                    "L'Id du superviseur est obligatoire." :
                    $"Une erreur est survenue lors de la récupération des utilisateurs : {await response.Content.ReadAsStringAsync()}");
            }
        }

        public async Task<decimal> GetStudentBonusAsync(string name, DateOnly startDate, DateOnly endDate)
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

        public async Task<int> GetNbOpenAccountsAsync(string name)
        {
            try
            {
                var apiUrl = _configuration.GetValue<string>("EDPApiUrl");
                var queryString = $"?name={Uri.EscapeDataString(name)}";

                var response = await new HttpClient().GetAsync($"{apiUrl}api/debitAccount{queryString}");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return await response.Content.ReadFromJsonAsync<int>();
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception("Le nom de l'étudiant est obligatoire.");
                }
                else
                {
                    throw new Exception($"Une erreur est survenue lors de la récupération du nombre de compte en prélèvements : {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération du nombre de compte en prélèvements : {ex.Message}");
                throw;
            }
        }

        public int GetNbOpenAccountsByPeriod(string name, DateOnly periodFirstDay, DateOnly periodLastDay)
        {
            try
            {
                var apiUrl = _configuration.GetValue<string>("EDPApiUrl");
                var queryString = $"?name={Uri.EscapeDataString(name)}&periodFirstDay={Uri.EscapeDataString(periodFirstDay.ToString("dd-MM-yyyy"))}&periodLastDay={Uri.EscapeDataString(periodLastDay.ToString("dd-MM-yyyy"))}";

                var response = new HttpClient().GetAsync($"{apiUrl}api/debitAccountByPeriod{queryString}").Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Content.ReadFromJsonAsync<int>().Result;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception("Le nom de l'étudiant et les dates de début et de fin de période est obligatoire.");
                }
                else
                {
                    throw new Exception($"Une erreur est survenue lors de la récupération du nombre de compte en prélèvements : {response.Content.ReadAsStringAsync().Result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération du nombre de compte en prélèvements : {ex.Message}");
                return 0;
            }
        }


        public async Task DeleteUserAsync(int userId)
        {
            var response = await new HttpClient().DeleteAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/users/{userId}");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Une erreur est survenue lors de la suppression de l'utilisateur : {await response.Content.ReadAsStringAsync()}");
        }

        public User? GetUserAD(string email)
        {
            using DirectorySearcher dirsearcher = new(Domain.GetDirectoryEntry(),
                                                          $"(&(objectClass=user)(mail=*{email}*))",
                                                          new string[] { "sn", "givenName", "mail", "company" });

            var user = dirsearcher.FindOne();
            if (user != null)
            {
                return new User()
                {
                    LastName = user.GetPropertyValue("sn"),
                    FirstName = user.GetPropertyValue("givenName"),
                    EmailAdress = user.GetPropertyValue("mail"),
                    Entity = user.GetPropertyValue("company"),
                };
            }
            else
            {
                return new User();
            }
        }

        #region APICRM
        public async Task<decimal> GetUserTurnover(string email, DateOnly beginningDate, DateOnly endingDate)
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

                string response = await _crmService.SendRequestToCRMApiAsync("api/Sales/GetWeeklyByUser", requestDataJson);

                dynamic responseObject = System.Text.Json.JsonSerializer.Deserialize<dynamic>(response);

                if (responseObject.ValueKind == JsonValueKind.Array)
                {
                    decimal totalAmount = 0;

                    foreach (JsonElement item in responseObject.EnumerateArray())
                    {
                        if (item.TryGetProperty("Amount", out JsonElement amountElement))
                        {
                            if (amountElement.TryGetDecimal(out decimal amount))
                            {
                                totalAmount += amount;
                            }
                        }
                    }

                    return totalAmount;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération du chiffre d'affaires : {ex.Message}");
                throw;
            }
        }

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
