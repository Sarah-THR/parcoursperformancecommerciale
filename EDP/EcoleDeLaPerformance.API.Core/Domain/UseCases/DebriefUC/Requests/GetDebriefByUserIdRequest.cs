using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.DebriefUC.Requests
{
    public class GetDebriefByUserIdRequest : IRequest<IEnumerable<Debrief>>
    {
        public DateTime startDateWeek { get; set; } = default!;
        public DateTime endDateWeek { get; set; } = default!;
        public int userId { get; set; } = default!;
    }

    public class GetDebriefByUserIdRequestHandler : IRequestHandler<GetDebriefByUserIdRequest, IEnumerable<Debrief>>
    {
        private readonly IDebriefReadRepository _debriefReadRepository;

        public GetDebriefByUserIdRequestHandler(IDebriefReadRepository debriefReadRepository)
        {
            _debriefReadRepository = debriefReadRepository;
        }

        public async Task<IEnumerable<Debrief>> Handle(GetDebriefByUserIdRequest request, CancellationToken cancellationToken)
        {
            if (request.startDateWeek == null)
                throw new ArgumentNullException("StartDateWeek", "La date de début est obligatoire.");
            if (request.endDateWeek == null)
                throw new ArgumentNullException("EndDateWeek", "La date de fin est obligatoire.");
            if (request.userId == null)
                throw new ArgumentNullException("UserId", "Un id utilisateur est obligatoire.");

            return await _debriefReadRepository.GetDebriefByUserAsync(request.startDateWeek, request.endDateWeek, request.userId);
        }
    }
}
