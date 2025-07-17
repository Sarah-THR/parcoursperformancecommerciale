using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Grades;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Grades;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<Grade, GradeResponse>();
            CreateMap<GradeRequest, Grade>();
            CreateMap<UpdateGradeRequest, Grade>();
        }
    }
}
