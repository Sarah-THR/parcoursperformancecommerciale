using EcoleDeLaPerformance.API.Core.Domain.UseCases.GradeUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Grades;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Grades;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Grades
{
    [HttpPost("grades"), AllowAnonymous]
    public class InsertGradeEndpoint : Endpoint<GradeRequest, GradeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertGradeEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(GradeRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<GradeResponse>(await _mediator.Send(new InsertGradeCommand
                {
                    grade = _mapper.Map<Core.Domain.Entities.Grade>(req)
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
