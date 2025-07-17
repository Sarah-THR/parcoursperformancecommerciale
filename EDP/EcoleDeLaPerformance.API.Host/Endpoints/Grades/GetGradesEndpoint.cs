using EcoleDeLaPerformance.API.Core.Domain.UseCases.GradeUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Grades;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Grades
{
    [HttpGet("grades"), AllowAnonymous]
    public class GetGradesEndpoint : EndpointWithoutRequest<IEnumerable<GradeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetGradesEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<GradeResponse>>(await _mediator.Send(new GetGradesRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
