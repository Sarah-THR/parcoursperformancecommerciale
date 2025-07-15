using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.HalfDayPlannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.HalfDayPlannings;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class HalfDayPlanningProfile : Profile
    {
        public HalfDayPlanningProfile()
        {
            CreateMap<HalfDayPlanning, HalfDayPlanningResponse>();
            CreateMap<HalfDayPlanningRequest, HalfDayPlanning>();
        }
    }
}
