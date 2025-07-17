using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.GradeUC.Requests
{
    public class GetGradesRequest : IRequest<IEnumerable<Grade>>
    {
    }

    public class GetGradesRequestHandler : IRequestHandler<GetGradesRequest, IEnumerable<Grade>>
    {
        private readonly IGradeReadRepository _gradeReadRepository;

        public GetGradesRequestHandler(IGradeReadRepository gradeReadRepository)
        {
            _gradeReadRepository = gradeReadRepository;
        }

        public async Task<IEnumerable<Grade>> Handle(GetGradesRequest request, CancellationToken cancellationToken)
        {
            return await _gradeReadRepository.GetGradesAsync();
        }
    }
}
