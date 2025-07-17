using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Users;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
        }
    }
}
