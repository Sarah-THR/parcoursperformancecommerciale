using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Models;
using System.Net;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class TaskPlanningService : ITaskPlanningService
    {
        private readonly IConfiguration _configuration;

        public TaskPlanningService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<TaskPlanning?>> GetAllTaskPlanning()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/taskplanning/");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<TaskPlanning?>>(),
                HttpStatusCode.NoContent => null,
                HttpStatusCode.BadRequest => throw new Exception("Une erreur est survenue."),
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des semaines de l'utilisateur : {await response.Content.ReadAsStringAsync()}"),
            };
        }

    }
}
