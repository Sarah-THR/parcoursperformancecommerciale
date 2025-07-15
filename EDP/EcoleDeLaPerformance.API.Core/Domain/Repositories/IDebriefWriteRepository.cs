using EcoleDeLaPerformance.API.Core.Domain.Entities;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IDebriefWriteRepository
    {
        Task<Debrief> InsertDebriefAsync(Debrief debrief);
        System.Threading.Tasks.Task DeleteDebriefAsync(int debriefId);
        System.Threading.Tasks.Task UpdateDebriefAsync(Debrief debrief);
    }
}
