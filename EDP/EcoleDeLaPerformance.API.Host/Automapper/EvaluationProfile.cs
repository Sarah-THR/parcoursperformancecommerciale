using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Evaluations;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Evaluations;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class EvaluationProfile : Profile
    {
        public EvaluationProfile()
        {
            CreateMap<Evaluation, EvaluationResponse>();
            CreateMap<EvaluationRequest, Evaluation>();
        }
    }
}
