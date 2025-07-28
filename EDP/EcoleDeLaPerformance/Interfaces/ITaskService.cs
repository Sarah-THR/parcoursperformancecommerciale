namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface ITaskService
    {
        Task<List<Models.Task?>> GetTasksAsync();
    }
}
