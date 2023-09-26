using AutoMapper;
using Newel.Server.Model;

namespace API.Models.UserModel
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequestModel, User>();
            CreateMap<User, UserResponseModel>();
        }
    }
}
