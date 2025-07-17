using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.FormationUC.Requests
{
    public class GetFormationsRequest : IRequest<IEnumerable<Formation>>
    {
    }

    public class GetFormationsRequestHandler : IRequestHandler<GetFormationsRequest, IEnumerable<Formation>>
    {
        private readonly IFormationReadRepository _formationReadRepository;

        public GetFormationsRequestHandler(IFormationReadRepository formationReadRepository)
        {
            _formationReadRepository = formationReadRepository;
        }

        public async Task<IEnumerable<Formation>> Handle(GetFormationsRequest request, CancellationToken cancellationToken)
        {
            return await _formationReadRepository.GetFormationsAsync();
        }
    }
}
