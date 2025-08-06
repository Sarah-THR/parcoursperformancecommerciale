using EcoleDeLaPerformance.API.Core.Domain.UseCases.FavoritesAgencyUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.FavoritesAgencies;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.FavoritesAgencies;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.FavoritesAgencies
{
    [HttpPost("favoritesagency"), AllowAnonymous]
    public class InsertFavoritesAgencyEndpoint : Endpoint<FavoritesAgencyRequest, FavoritesAgencyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertFavoritesAgencyEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(FavoritesAgencyRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<FavoritesAgencyResponse>(await _mediator.Send(new InsertFavoritesAgencyCommand
                {
                    favoritesAgency = _mapper.Map<Core.Domain.Entities.FavoritesAgency>(req)
                }, ct));

                await SendOkAsync(result, ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }
    }
}
