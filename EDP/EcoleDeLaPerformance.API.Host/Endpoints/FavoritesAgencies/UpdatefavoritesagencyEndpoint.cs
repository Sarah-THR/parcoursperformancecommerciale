using EcoleDeLaPerformance.API.Core.Domain.UseCases.FavoritesAgencyUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.FavoritesAgencies;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.FavoritesAgencies
{
    [HttpPut("favoritesagency"), AllowAnonymous]
    public class UpdatefavoritesagencyEndpoint : Endpoint<FavoritesAgencyRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdatefavoritesagencyEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(FavoritesAgencyRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateFavoritesAgencyCommand
                {
                    favoritesAgency = _mapper.Map<Core.Domain.Entities.FavoritesAgency>(req)
                }, ct);

                await SendOkAsync(ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
            catch (ArgumentException)
            {
                await SendNotFoundAsync(cancellation: ct);
            }
        }
    }
}
