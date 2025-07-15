using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using EcoleDeLaPerformance.API.Core.Domain.UseCases.ClassUC.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.TaskPlanningUC
{
    public class GetAllTaskPlanningRequest : IRequest<IEnumerable<Entities.Task>>
    {
    }

    public class GetAllTaskPlanningRequestHandler : IRequestHandler<GetAllTaskPlanningRequest, IEnumerable<Entities.Task>>
    {
        private readonly ITaskPlanningReadRepository _taskPlanningReadRepository;

        public GetAllTaskPlanningRequestHandler(ITaskPlanningReadRepository taskPlanningReadRepository)
        {
            _taskPlanningReadRepository = taskPlanningReadRepository;
        }

        public async Task<IEnumerable<Entities.Task>> Handle(GetAllTaskPlanningRequest request, CancellationToken cancellationToken)
        {
            return await _taskPlanningReadRepository.GetAllTaskPlanning();
        }
    }
}
