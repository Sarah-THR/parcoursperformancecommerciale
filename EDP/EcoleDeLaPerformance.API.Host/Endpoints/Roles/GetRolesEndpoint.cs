using EcoleDeLaPerformance.API.Core.Domain.UseCases.RoleUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Roles;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;


namespace EcoleDeLaPerformance.API.Host.Endpoints.Roles
{
    [HttpGet("roles"), AllowAnonymous]
    public class GetRolesEndpoint : EndpointWithoutRequest<IEnumerable<RoleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetRolesEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<RoleResponse>>(await _mediator.Send(new GetRolesRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
