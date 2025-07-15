using EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Users
{
    [HttpGet("users"), AllowAnonymous]
    public class GetUsersEndpoint : EndpointWithoutRequest<IEnumerable<UserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetUsersEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<UserResponse>>(await _mediator.Send(new GetUsersRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
