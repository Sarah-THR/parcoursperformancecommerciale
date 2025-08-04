using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.RoleUC.Requests
{
    public class GetRolesRequest : IRequest<IEnumerable<Role>>
    {
    }

    public class GetRolesRequestHandler : IRequestHandler<GetRolesRequest, IEnumerable<Role>>
    {
        private readonly IRoleReadRepository _roleReadRepository;

        public GetRolesRequestHandler(IRoleReadRepository roleReadRepository)
        {
            _roleReadRepository = roleReadRepository;
        }

        public async Task<IEnumerable<Role>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            return await _roleReadRepository.GetRolesAsync();
        }
    }
}
