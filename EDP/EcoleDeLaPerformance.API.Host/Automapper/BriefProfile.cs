using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Briefs;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Briefs;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class BriefProfile : Profile
    {
        public BriefProfile()
        {
            CreateMap<Brief, BriefResponse>();
            CreateMap<BriefRequest, Brief>();
            CreateMap<UpdateBriefRequest, Brief>();
        }
    }
}
