using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.TaskUC.Requests
{
    public class GetTasksRequest : IRequest<IEnumerable<Entities.Task>>
    {
    }

    public class GetTasksRequestHandler : IRequestHandler<GetTasksRequest, IEnumerable<Entities.Task>>
    {
        private readonly ITaskReadRepository _taskReadRepository;

        public GetTasksRequestHandler(ITaskReadRepository taskReadRepository)
        {
            _taskReadRepository = taskReadRepository;
        }

        public async Task<IEnumerable<Entities.Task>> Handle(GetTasksRequest request, CancellationToken cancellationToken)
        {
            return await _taskReadRepository.GetTasksAsync();
        }
    }
}
