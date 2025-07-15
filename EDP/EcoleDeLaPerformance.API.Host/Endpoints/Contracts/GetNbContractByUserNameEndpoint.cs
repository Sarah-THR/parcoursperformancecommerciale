using EcoleDeLaPerformance.API.Core.Domain.UseCases.ContractUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Contract;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Contracts
{
    [HttpGet("contracts/{commercial}/{startDate}/{endDate}"), AllowAnonymous]
    public class GetNbContractByUserNameEndpoint : Endpoint<GetNbContractsRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetNbContractByUserNameEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(GetNbContractsRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<int>(await _mediator.Send(new GetNbContractByUserNameRequest
                {
                    Commercial = req.Commercial,
                    StartDate = req.StartDate,
                    EndDate = req.EndDate,
                }, ct));

                if (result == 0) 
                    await SendNoContentAsync(cancellation: ct);
                else
                    await SendOkAsync(result, ct);
            }
            catch (ArgumentNullException)
            {
                await SendErrorsAsync(cancellation: ct);
            }
        }
    }
}
