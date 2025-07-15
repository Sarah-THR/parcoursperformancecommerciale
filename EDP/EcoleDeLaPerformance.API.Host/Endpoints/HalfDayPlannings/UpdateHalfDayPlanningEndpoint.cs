using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Commands;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.HalfDayPlanningUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.BriefNotes;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.HalfDayPlannings;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.HalfDayPlannings
{
    [HttpPut("halfdayplanning/"), AllowAnonymous]

    public class UpdateHalfDayPlanningEndpoint: Endpoint<HalfDayPlanningRequest>
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateHalfDayPlanningEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async System.Threading.Tasks.Task HandleAsync(HalfDayPlanningRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateHalfDayPlanningCommand
                {
                    halfDayPlanning = _mapper.Map<HalfDayPlanning>(req)
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
