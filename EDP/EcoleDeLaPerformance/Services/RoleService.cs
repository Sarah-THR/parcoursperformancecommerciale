using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using System.Net;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class RoleService: IRoleService
    {
        private readonly IConfiguration _configuration;

        public RoleService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Role?>> GetRolesAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/roles");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Role?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des roles : {await response.Content.ReadAsStringAsync()}"),
            };
        }
    }
}
