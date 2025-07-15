using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.ClassUC.Requests
{
    public class GetClassesRequest : IRequest<IEnumerable<Class>>
    {
    }

    public class GetClassesRequestHandler : IRequestHandler<GetClassesRequest, IEnumerable<Class>>
    {
        private readonly IClassReadRepository _classReadRepository;

        public GetClassesRequestHandler(IClassReadRepository classReadRepository)
        {
            _classReadRepository = classReadRepository;
        }

        public async Task<IEnumerable<Class>> Handle(GetClassesRequest request, CancellationToken cancellationToken)
        {
            return await _classReadRepository.GetClassesAsync();
        }
    }
}
