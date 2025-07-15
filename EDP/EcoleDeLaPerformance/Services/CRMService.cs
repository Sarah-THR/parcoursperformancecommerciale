using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using EcoleDeLaPerformance.Ui.Models;
using System.Text;
using System.Net;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class CRMService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger<CRMService> _logger;
        private Token _token;

        public CRMService(HttpClient httpClient, IConfiguration configuration, ILogger<CRMService> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _token = new Token();
        }

        public async Task GetCrmTokenAsync()
        {
            var crmSettings = _configuration.GetSection("CRMAPI");

            var parameters = new
            {
                username = crmSettings["Username"],
                password = crmSettings["Password"],
                domain = crmSettings["Domain"],
                server = crmSettings["Server"],
                organization = crmSettings["Organization"],
            };

            Regex rgx = new Regex(@"jwt"":""(.+?)""");

            string token = await SendRequestToCRMApiAsync("api/Auth/Login", JsonSerializer.Serialize(parameters));
            if (string.IsNullOrEmpty(token))
            {
                using (StreamWriter writer = new StreamWriter("Log.txt", true))
                {
                    writer.WriteLine($"{DateTime.Now} : Token null | Erreur Connecteur CRM");
                    writer.Close();
                }
                return;
            }

            _token.Value = rgx.Match(token).Groups[1].Value;
            _token.ExpireAt = DateTime.Now.AddMinutes(20);
        }

        public async Task<string> SendRequestToCRMApiAsync(string route, string jsonData)
        {
            var crmSettings = _configuration.GetSection("CRMAPI");
            var ApiUrl = crmSettings["ApiUrl"];

            return await SendRequestToApiAsync(ApiUrl + route, jsonData, _token.Value ?? string.Empty);
        }

        public async Task<string> SendRequestToApiAsync(string apiUrl, string jsonData, string jwtToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Clear();
                if (!string.IsNullOrEmpty(jwtToken))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                }

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                _logger.LogError($"Unauthorized access: {ex.Message}");
                Console.WriteLine($"Unauthorized access: {ex.Message}");
                throw;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                _logger.LogError($"Bad request: {ex.Message}"); 
                Console.WriteLine($"Bad request: {ex.Message}");
                throw;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"API Request Error: {ex.Message}");
                Console.WriteLine($"API Request Error: {ex.Message}");
                throw;
            }
        }

    }
}
