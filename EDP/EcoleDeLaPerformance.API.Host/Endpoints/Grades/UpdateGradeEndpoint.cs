using EcoleDeLaPerformance.API.Core.Domain.UseCases.GradeUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Grades;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Grades
{
    [HttpPut("grades"), AllowAnonymous]
    public class UpdateGradeEndpoint : Endpoint<GradeRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateGradeEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(GradeRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateGradeCommand
                {
                    grade = _mapper.Map<Core.Domain.Entities.Grade>(req)
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
