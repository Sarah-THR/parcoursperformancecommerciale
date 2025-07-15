using EcoleDeLaPerformance.API.Core.Domain.UseCases.ContractUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Contract;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Contracts;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Contracts
{
    [HttpGet("contractssale/{commercial}"), AllowAnonymous]
    public class GetContractSaleEndpoint : Endpoint<GetContractSaleRequest, IEnumerable<ContractSaleResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetContractSaleEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(GetContractSaleRequest req, CancellationToken ct)
        {
            try
            {
                var result = _mapper.Map<IEnumerable<ContractSaleResponse>>(await _mediator.Send(new GetContractSaleByUserNameRequest
                {
                    Commercial = req.Commercial
                }, ct));

                if (result == null)
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
