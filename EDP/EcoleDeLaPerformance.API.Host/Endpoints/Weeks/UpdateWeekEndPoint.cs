using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.WeekUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Weeks;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Weeks
{
    [HttpPut("weeks/"), AllowAnonymous]

    public class UpdateWeekEndPoint : Endpoint<WeekRequest>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateWeekEndPoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async System.Threading.Tasks.Task HandleAsync(WeekRequest req, CancellationToken ct)
        {
            try
            {
                await _mediator.Send(new UpdateWeekCommand
                {
                    week = _mapper.Map<Week>(req)
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
