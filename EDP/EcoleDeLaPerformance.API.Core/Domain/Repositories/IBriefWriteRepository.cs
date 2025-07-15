using EcoleDeLaPerformance.API.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.Repositories
{
    public interface IBriefWriteRepository
    {
        Task<Brief> InsertBriefAsync(Brief brief);
        System.Threading.Tasks.Task DeleteBriefAsync(int briefId);
        System.Threading.Tasks.Task UpdateBriefAsync(Brief brief);

    }
}
