namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface ITaskReadRepository
    {
        Task<List<Core.Domain.Entities.Task?>> GetTasksAsync();
    }
}
