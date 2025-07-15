using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.TaskPlannings;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class TaskPlanningProfile : Profile
    {
        public TaskPlanningProfile()
        {
            CreateMap<Core.Domain.Entities.Task, TaskPlanningResponse>();
        }
    }
}
