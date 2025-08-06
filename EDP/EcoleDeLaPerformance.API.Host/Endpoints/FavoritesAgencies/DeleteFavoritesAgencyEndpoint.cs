using EcoleDeLaPerformance.API.Core.Domain.UseCases.FavoritesAgencyUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.FavoritesAgencies;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace EcoleDeLaPerformance.API.Host.Endpoints.FavoritesAgencies
{
    [HttpDelete("favoritesagency/{Id:Int}"), AllowAnonymous]
    public class DeleteFavoritesAgencyEndpoint : Endpoint<FavoritesAgencyRequest>
    {
        private readonly IMediator _mediator;
        public DeleteFavoritesAgencyEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task HandleAsync(FavoritesAgencyRequest req, CancellationToken ct)
        {
            await _mediator.Send(new DeleteFavoritesAgencyCommand
            {
                Id = req.Id
            }, ct);

            await SendOkAsync(ct);
        }

    }
}
