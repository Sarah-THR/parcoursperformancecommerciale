using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.PlanningUC.Requests
{
    public class GetPlanningsByUserId : IRequest<IEnumerable<Planning>>
    {
        public DateTime startDateWeek { get; set; } = default!;
        public DateTime endDateWeek { get; set; } = default!;
        public int userId { get; set; } = default!;
    }

    public class GetPlanningsByUserIdHandler : IRequestHandler<GetPlanningsByUserId, IEnumerable<Planning>>
    {
        private readonly IPlanningReadRepository _planningReadRepository;

        public GetPlanningsByUserIdHandler(IPlanningReadRepository planningReadRepository)
        {
            _planningReadRepository = planningReadRepository;
        }

        public async Task<IEnumerable<Planning>> Handle(GetPlanningsByUserId request, CancellationToken cancellationToken)
        {
            if (request.startDateWeek == null)
                throw new ArgumentNullException("StartDateWeek", "La date de début est obligatoire.");
            if (request.endDateWeek == null)
                throw new ArgumentNullException("EndDateWeek", "La date de fin est obligatoire.");
            if (request.userId == null)
                throw new ArgumentNullException("UserId", "Un id utilisateur est obligatoire.");

            return await _planningReadRepository.GetPlanningByUserAsync(request.startDateWeek, request.endDateWeek, request.userId);
        }
    }
}
