using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using System.Net;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class StatusService : IStatusService
    {
        private readonly IConfiguration _configuration;

        public StatusService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Status?>> GetStatusesAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/statuses");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Status?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des Statuses : {await response.Content.ReadAsStringAsync()}"),
            };
        }
    }
}
