using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.FavoritesAgencyUC.Commands
{
    public class InsertFavoritesAgencyCommand : IRequest<FavoritesAgency>
    {
        public FavoritesAgency favoritesAgency = default!;

        public class InsertFavoritesAgencyCommandHandler : IRequestHandler<InsertFavoritesAgencyCommand, FavoritesAgency>
        {
            private readonly IFavoritesAgencyWriteRepository _favoritesAgencyWriteRepository;

            public InsertFavoritesAgencyCommandHandler(IFavoritesAgencyWriteRepository favoritesAgencyWriteRepository)
            {
                _favoritesAgencyWriteRepository = favoritesAgencyWriteRepository;
            }

            public async Task<FavoritesAgency> Handle(InsertFavoritesAgencyCommand command, CancellationToken cancellationToken)
            {
                if (command.favoritesAgency == null)
                    throw new ArgumentNullException("favoritesAgency", "L'agence favorites à insérer est obligatoire.");

                command.favoritesAgency.CreatedAt = DateTime.Now;
                return await _favoritesAgencyWriteRepository.InsertFavoritesAgencyAsync(command.favoritesAgency);

            }
        }
    }
}
