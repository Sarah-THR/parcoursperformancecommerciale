using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Classes;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassResponse>();
            CreateMap<Class, DocumentClassResponse>();
        }
    }
}
