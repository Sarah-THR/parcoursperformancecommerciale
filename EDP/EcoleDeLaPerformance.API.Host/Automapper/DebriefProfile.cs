using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Debriefs;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Debriefs;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class DebriefProfile : Profile
    {
        public DebriefProfile()
        {
            CreateMap<Debrief, DebriefResponse>();
            CreateMap<DebriefRequest, Debrief>();
            CreateMap<UpdateDebriefRequest, Debrief>();
        }
    }
}
