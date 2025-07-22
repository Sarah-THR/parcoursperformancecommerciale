using EcoleDeLaPerformance.Ui.Interfaces;
using System.Net;

namespace EcoleDeLaPerformance.Ui.Services
{
    public class TaskService : ITaskService
    {
        private readonly IConfiguration _configuration;

        public TaskService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Task?>> GetTasksAsync()
        {
            var response = await new HttpClient().GetAsync($"{_configuration.GetValue<string>("EDPApiUrl")}api/tasks");

            return response.StatusCode switch
            {
                HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<List<Task?>>(),
                HttpStatusCode.NoContent => null,
                _ => throw new Exception($"Une erreur est survenue lors de la récupération des Tasks : {await response.Content.ReadAsStringAsync()}"),
            };
        }
    }
}
