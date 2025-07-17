using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Formations;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Formations;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class FormationProfile : Profile
    {
        public FormationProfile()
        {
            CreateMap<Formation, FormationResponse>();
            CreateMap<FormationRequest, Formation>();
            CreateMap<UpdateFormationRequest, Formation>();
        }
    }
}
