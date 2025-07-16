using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.UsersFormations;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.UsersFormations;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class UsersFormationProfile : Profile
    {
        public UsersFormationProfile()
        {
            CreateMap<UsersFormation, UsersFormationResponse>();
            CreateMap<UsersFormationRequest, UsersFormation>();
        }
    }
}
