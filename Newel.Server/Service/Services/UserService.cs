using AutoMapper;
using Newel.Server.Model;
using Newel.Server.Repositories;
using Service.Services.Interfaces;
using Service.ViewModels.UserViewModels;

namespace Service.Services
{
    public class UserService : BaseService<User, UserViewModel, UserRepository>, IUserService
    {
        public UserService(UserRepository _repository, IMapper _mapper) : base(_repository, _mapper)
        {
        }
    }
}
