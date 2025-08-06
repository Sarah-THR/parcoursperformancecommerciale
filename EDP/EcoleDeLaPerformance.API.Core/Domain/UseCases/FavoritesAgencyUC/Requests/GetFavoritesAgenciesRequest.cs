using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.FavoritesAgencyUC.Requests
{
    public class GetFavoritesAgenciesRequest : IRequest<IEnumerable<FavoritesAgency>>
    {
    }

    public class GetFavoritesAgenciesRequestHandler : IRequestHandler<GetFavoritesAgenciesRequest, IEnumerable<FavoritesAgency>>
    {
        private readonly IFavoritesAgencyReadRepository _favoritesAgencyReadRepository;

        public GetFavoritesAgenciesRequestHandler(IFavoritesAgencyReadRepository favoritesAgencyReadRepository)
        {
            _favoritesAgencyReadRepository = favoritesAgencyReadRepository;
        }

        public async Task<IEnumerable<FavoritesAgency>> Handle(GetFavoritesAgenciesRequest request, CancellationToken cancellationToken)
        {
            return await _favoritesAgencyReadRepository.GetFavoritesAgenciesAsync();
        }
    }
}
