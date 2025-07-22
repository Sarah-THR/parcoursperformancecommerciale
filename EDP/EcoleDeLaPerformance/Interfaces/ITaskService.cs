namespace EcoleDeLaPerformance.Ui.Interfaces
{
    public interface ITaskService
    {
        Task<List<Task?>> GetTasksAsync();
    }
}
