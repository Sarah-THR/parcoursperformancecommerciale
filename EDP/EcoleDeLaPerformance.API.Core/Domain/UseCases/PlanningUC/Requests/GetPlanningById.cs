using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Requests
{
    public class GetPlanningById : IRequest<Planning>
    {
        public int id { get; set; } = default!;
    }

    public class GetPlanningByIdHandler : IRequestHandler<GetPlanningById, Planning>
    {
        private readonly IPlanningReadRepository _planningReadRepository;

        public GetPlanningByIdHandler(IPlanningReadRepository planningReadRepository)
        {
            _planningReadRepository = planningReadRepository;
        }

        public async Task<Planning> Handle(GetPlanningById request, CancellationToken cancellationToken)
        {
            if (request.id == null)
                throw new ArgumentNullException("Id", "Un id est obligatoire.");

            return await _planningReadRepository.GetPlanningByIdAsync(request.id);
        }
    }
}
