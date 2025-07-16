using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.PlanningsTasks;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.PlanningsTasks;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class PlanningsTaskProfile : Profile
    {
        public PlanningsTaskProfile()
        {
            CreateMap<PlanningsTask, PlanningsTaskResponse>();
            CreateMap<PlanningsTaskRequest, PlanningsTask>();
        }
    }
}
