using EcoleDeLaPerformance.API.Core.Domain.UseCases.WeekUC.Commands;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Weeks;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Weeks;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Weeks
{
    [HttpPost("weeks"), AllowAnonymous]
    public class CreateWeekEndpoint : Endpoint<WeekRequest, WeekResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateWeekEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async System.Threading.Tasks.Task HandleAsync(WeekRequest req, CancellationToken ct)
        {
            try
            {
                await SendOkAsync(_mapper.Map<WeekResponse>(await _mediator.Send(new CreateWeekCommand
                {
                    week = _mapper.Map<Week>(req)
                }, ct)), ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }
    }
}
