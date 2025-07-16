using AutoMapper;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Tasks;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Tasks;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Core.Domain.Entities.Task, TaskResponse>();
            CreateMap<TaskRequest, Core.Domain.Entities.Task>();
        }
    }
}
