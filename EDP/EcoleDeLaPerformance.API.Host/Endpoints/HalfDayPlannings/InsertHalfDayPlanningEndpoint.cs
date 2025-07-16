using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.BriefNotes;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.HalfDayPlannings;
using FastEndpoints;
using IMapper = AutoMapper.IMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.HalfDayPlannings;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.HalfDayPlanningUC.Commands;

namespace EcoleDeLaPerformance.API.Host.Endpoints.HalfDayPlannings
{
    [HttpPost("halfdayplanning/InsertHalfDayPlanning"), AllowAnonymous]

    public class InsertHalfDayPlanningEndpoint : Endpoint<HalfDayPlanningRequest, PlanningResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertHalfDayPlanningEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async System.Threading.Tasks.Task HandleAsync(HalfDayPlanningRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<PlanningResponse>(await _mediator.Send(new InsertHalfDayPlanningCommand
                {
                    halfDayPlanning = _mapper.Map<HalfDayPlanning>(req)
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
