using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.CategoryUC.Requests
{
    public class GetCategoriesRequest : IRequest<IEnumerable<Category>>
    {
    }

    public class GetCategoriesRequestHandler : IRequestHandler<GetCategoriesRequest, IEnumerable<Category>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetCategoriesRequestHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            return await _categoryReadRepository.GetCategoriesAsync();
        }
    }
}
