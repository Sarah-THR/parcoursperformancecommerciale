using EcoleDeLaPerformance.API.Core.Domain.UseCases.CategoryUC.Requests;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Categories;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using IMapper = AutoMapper.IMapper;

namespace EcoleDeLaPerformance.API.Host.Endpoints.Categories
{
    [HttpGet("categories"), AllowAnonymous]
    public class GetCategoriesEndpoint : EndpointWithoutRequest<IEnumerable<CategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetCategoriesEndpoint(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<CategoryResponse>>(await _mediator.Send(new GetCategoriesRequest(), ct));

            if (result == null)
                await SendNoContentAsync(ct);
            else
                await SendOkAsync(result, ct);
        }
    }
}
