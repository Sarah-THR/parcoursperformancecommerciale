using EcoleDeLaPerformance.API.Core.Domain.UseCases.HalfDayPlanningUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.HalfDayPlannings;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.HalfDayPlannings;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.HalfDayPlannings
{
    [HttpGet("halfdayplanning/{WeekId:int}"), AllowAnonymous]

    public class GetHalfDayPlanningByWeekIdEndpoint(IMapper mapper, IMediator mediator) : Endpoint<HalfDayPlanningByWeekIdRequest, IEnumerable<HalfDayPlanningResponse>>
    {
        public override async Task HandleAsync(HalfDayPlanningByWeekIdRequest req, CancellationToken ct)
        {
            var result = mapper.Map<IEnumerable<HalfDayPlanningResponse>>(await mediator.Send(new GetHalfDayPlanningByWeekIdRequest
            {
                weekId = req.WeekId,
            }, ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
