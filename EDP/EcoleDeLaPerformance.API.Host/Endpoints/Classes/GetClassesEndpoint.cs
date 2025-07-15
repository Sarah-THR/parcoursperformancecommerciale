using EcoleDeLaPerformance.API.Core.Domain.UseCases.ClassUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Classes;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Classes
{
    [HttpGet("classes"), AllowAnonymous]
    public class GetClassesEndpoint : EndpointWithoutRequest<IEnumerable<ClassResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetClassesEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<ClassResponse>>(await _mediator.Send(new GetClassesRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
