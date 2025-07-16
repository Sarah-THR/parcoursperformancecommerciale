using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Statuses;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Statuses;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusResponse>();
            CreateMap<StatusRequest, Status>();
        }
    }
}
