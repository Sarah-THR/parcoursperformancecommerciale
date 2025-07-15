using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Requests;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.BriefNoteUC.Requests
{
    public class GetWeekNoteByUserRequest : IRequest<IEnumerable<BriefNote>>
    {
        public DateTime startDateWeek { get; set; } = default!;
        public DateTime endDateWeek { get; set; } = default!;
        public int userId { get; set; } = default!;
    }

    public class WeekNoteByUserRequestHandler : IRequestHandler<GetWeekNoteByUserRequest, IEnumerable<BriefNote>>
    {
        private readonly IBriefReadRepository _briefNoteReadRepository;

        public WeekNoteByUserRequestHandler(IBriefReadRepository briefNoteReadRepository)
        {
            _briefNoteReadRepository = briefNoteReadRepository;
        }

        public async Task<IEnumerable<BriefNote>> Handle(GetWeekNoteByUserRequest request, CancellationToken cancellationToken)
        {
            if (request.startDateWeek == null)
                throw new ArgumentNullException("StartDateWeek", "La date de début est obligatoire.");
            if (request.endDateWeek == null)
                throw new ArgumentNullException("EndDateWeek", "La date de fin est obligatoire.");
            if (request.userId == null)
                throw new ArgumentNullException("UserId", "Un id utilisateur est obligatoire.");

            return await _briefNoteReadRepository.GetWeekNoteByUser(request.startDateWeek,request.endDateWeek, request.userId);
        }
    }
}
