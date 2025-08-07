using EcoleDeLaPerformance.API.Core.Domain.UseCases.FavoritesAgencyUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.FavoritesAgencies;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.FavoritesAgencies;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.FavoritesAgencies
{
    [HttpGet("favoritesagency"), AllowAnonymous]
    public class GetFavoritesAgenciesEndpoint : Endpoint<FavoritesAgencyByUserIdRequest, IEnumerable<FavoritesAgencyResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetFavoritesAgenciesEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public override async Task HandleAsync(FavoritesAgencyByUserIdRequest req, CancellationToken ct)
        {
            try
            {
                var results = await _mediator.Send(new GetFavoritesAgenciesRequest
                {
                    UserId = req.UserId,
                }, ct);

                await SendOkAsync(_mapper.Map<IEnumerable<FavoritesAgencyResponse>>(results), ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }
    }
}
