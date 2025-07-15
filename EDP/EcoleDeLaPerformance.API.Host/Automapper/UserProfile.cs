using AutoMapper;
using EcoleDeLaPerformance.API.Core.Domain.Entities;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Users;
using EcoleDeLaPerformance.API.Host.Contracts.Requests.Weeks;
using EcoleDeLaPerformance.API.Host.Contracts.Responses.Users;
using System.Data;
using System.Security;

namespace EcoleDeLaPerformance.API.Host.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, SupervisorNavigationResponse>();

        }
    }
}
