using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.FavoritesAgencyUC.Commands
{
    public class UpdateFavoritesAgencyCommand : IRequest
    {
        public FavoritesAgency favoritesAgency = default!;
    }

    public class UpdateFavoritesAgencyCommandHandler : IRequestHandler<UpdateFavoritesAgencyCommand>
    {
        private readonly IFavoritesAgencyWriteRepository _favoritesAgencyWriteRepository;

        public UpdateFavoritesAgencyCommandHandler(IFavoritesAgencyWriteRepository favoritesAgencyWriteRepository)
        {
            _favoritesAgencyWriteRepository = favoritesAgencyWriteRepository;
        }

        public async System.Threading.Tasks.Task Handle(UpdateFavoritesAgencyCommand command, CancellationToken cancellationToken)
        {
            if (command.favoritesAgency == null)
                throw new ArgumentNullException("FavoritesAgency", "L'agence favorite à modifier est obligatoire.");
            command.favoritesAgency.UpdatedAt = DateTime.Now;
            await _favoritesAgencyWriteRepository.UpdateFavoritesAgencyAsync(command.favoritesAgency);
        }
    }
}
