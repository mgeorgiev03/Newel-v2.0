using AutoMapper;
using Newel.Server.Model;

namespace Service.ViewModels.UserViewModels
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<UserUpdateViewModel, UserViewModel>().ReverseMap();
        }
    }
}
