using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.HalfDayPlanningUC.Requests
{
    public class GetHalfDayPlanningByWeekIdRequest : IRequest<IEnumerable<HalfDayPlanning?>>
    {
        public int weekId { get; set; } = default!;
    }

    public class GetHalfDayPlanningByWeekIdRequestHandler : IRequestHandler<GetHalfDayPlanningByWeekIdRequest, IEnumerable<HalfDayPlanning?>>
    {
        private readonly IHalfDayPlanningReadRepository _halfDayPlanningReadRepository;

        public GetHalfDayPlanningByWeekIdRequestHandler(IHalfDayPlanningReadRepository halfDayPlanningReadRepository)
        {
            _halfDayPlanningReadRepository = halfDayPlanningReadRepository;
        }

        public async Task<IEnumerable<HalfDayPlanning?>> Handle(GetHalfDayPlanningByWeekIdRequest request, CancellationToken cancellationToken)
        {
            return await _halfDayPlanningReadRepository.GetHalfDayPlanningByWeekIdAsync(request.weekId);
        }
    }
}
