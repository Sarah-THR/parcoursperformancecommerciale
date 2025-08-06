using EcoleDeLaPerformance.API.Core.Domain.UseCases.FavoritesAgencyUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.FavoritesAgencies;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.FavoritesAgencies
{
    [HttpGet("favoritesagency"), AllowAnonymous]
    public class GetFavoritesAgenciesEndpoint : EndpointWithoutRequest<IEnumerable<FavoritesAgencyResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetFavoritesAgenciesEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<FavoritesAgencyResponse>>(await _mediator.Send(new GetFavoritesAgenciesRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
