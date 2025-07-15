using EcoleDeLaPerformance.Ui.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class SalesUpService
    {
        private readonly HttpClient _httpClient;

        public SalesUpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetToken(string authUrl, string email, string password)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, authUrl);
                var requestBody = new SalesUpTokenRequest
                {
                    Email = email,
                    Password = password
                };

                string jsonBody = JsonSerializer.Serialize(requestBody);
                request.Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();
                SalesUpToken tokenResponse = JsonSerializer.Deserialize<SalesUpToken>(jsonString);

                return tokenResponse.AccessToken;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> GetUserIdByEmail(string token, string userEmail)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/rest-api/users/search");

                request.Headers.Authorization = new AuthenticationHeaderValue(token);

                var requestBody = new SearchUserRequest
                {
                    Search = new Search
                    {
                        Selects = new List<Select>
                        {
                            new Select { Field = "id" }
                        },
                        Filters = new List<Filter>
                        {
                            new Filter { Field = "email", Value = $"{userEmail}" }
                        }
                    }
                };

                string jsonBody = JsonSerializer.Serialize(requestBody);
                request.Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();
                SalesUpUser userResponse = JsonSerializer.Deserialize<SalesUpUser>(jsonString);

                return int.Parse(userResponse.Ids.FirstOrDefault().Id);
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> GetUserBonusById(string token, int userId)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/dashboard/unlock-amount");

                request.Headers.Authorization = new AuthenticationHeaderValue(token);

                var requestBody = new BonusRequest
                {
                    Date = DateTime.Now.ToString("yyyy-MM"),
                    Ids = new List<string>
                    {
                        userId.ToString()
                    },
                    Type = "user"
                };

                string jsonBody = JsonSerializer.Serialize(requestBody);
                request.Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();

                Bonus bonusResponse = JsonSerializer.Deserialize<Bonus>(jsonString);

                return bonusResponse.Value;
            }
            catch
            {
                return 0;
            }
        }
    }
}
