using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.FavoritesAgencyUC.Commands
{
    public class DeleteFavoritesAgencyCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteFavoritesAgencyCommandHandler : IRequestHandler<DeleteFavoritesAgencyCommand>
    {
        private readonly IFavoritesAgencyWriteRepository _favoritesAgencyWriteRepository;

        public DeleteFavoritesAgencyCommandHandler(IFavoritesAgencyWriteRepository favoritesAgencyWriteRepository)
        {
            _favoritesAgencyWriteRepository = favoritesAgencyWriteRepository;
        }

        public async Task Handle(DeleteFavoritesAgencyCommand command, CancellationToken cancellationToken)
        {
            await _favoritesAgencyWriteRepository.DeleteFavoritesAgencyAsync(command.Id);
        }
    }
}
