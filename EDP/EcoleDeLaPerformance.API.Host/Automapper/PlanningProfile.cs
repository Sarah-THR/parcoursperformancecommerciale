using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Plannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Plannings;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class PlanningProfile : Profile
    {
        public PlanningProfile()
        {
            CreateMap<Planning, PlanningResponse>();
            CreateMap<PlanningRequest, Planning>();
        }
    }
}
