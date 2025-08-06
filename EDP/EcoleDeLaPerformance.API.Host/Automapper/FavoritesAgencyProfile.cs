using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.FavoritesAgencies;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.FavoritesAgencies;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class FavoritesAgencyProfile : Profile
    {
        public FavoritesAgencyProfile()
        {
            CreateMap<FavoritesAgency, FavoritesAgencyResponse>();
            CreateMap<FavoritesAgencyRequest, FavoritesAgency>();
        }
    }
}
