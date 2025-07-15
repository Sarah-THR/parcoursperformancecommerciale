using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Weeks;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Weeks;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class WeekProfile : Profile
    {
        public WeekProfile()
        {
            CreateMap<Week, WeekResponse>();
            CreateMap<WeekRequest, Week>();
        }
    }
}
