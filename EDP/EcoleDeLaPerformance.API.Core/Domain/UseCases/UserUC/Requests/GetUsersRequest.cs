using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Core.Domain.Repositories;
using MediatR;

namespace EcoleDeLaPerformance.API.Core.Domain.UseCases.UserUC.Requests
{
    public class GetUsersRequest : IRequest<IEnumerable<User>>
    {
    }

    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, IEnumerable<User>>
    {
        private readonly IUserReadRepository _userReadRepository;

        public GetUsersRequestHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            return await _userReadRepository.GetUsersAsync();
        }
    }
}
