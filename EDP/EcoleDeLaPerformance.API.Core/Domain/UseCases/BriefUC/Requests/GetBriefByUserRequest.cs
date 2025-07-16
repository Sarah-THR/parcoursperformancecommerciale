using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefUC.Requests
{
    public class GetBriefByUserRequest : IRequest<IEnumerable<Brief>>
    {
        public DateTime startDateWeek { get; set; } = default!;
        public DateTime endDateWeek { get; set; } = default!;
        public int userId { get; set; } = default!;
    }

    public class BriefByUserRequestHandler : IRequestHandler<GetBriefByUserRequest, IEnumerable<Brief>>
    {
        private readonly IBriefReadRepository _briefReadRepository;

        public BriefByUserRequestHandler(IBriefReadRepository briefReadRepository)
        {
            _briefReadRepository = briefReadRepository;
        }

        public async Task<IEnumerable<Brief>> Handle(GetBriefByUserRequest request, CancellationToken cancellationToken)
        {
            if (request.startDateWeek == null)
                throw new ArgumentNullException("StartDateWeek", "La date de début est obligatoire.");
            if (request.endDateWeek == null)
                throw new ArgumentNullException("EndDateWeek", "La date de fin est obligatoire.");
            if (request.userId == null)
                throw new ArgumentNullException("UserId", "Un id utilisateur est obligatoire.");

            return await _briefReadRepository.GetBriefByUserAsync(request.startDateWeek, request.endDateWeek, request.userId);
        }
    }
}
