using Newel.Server.Model;
using Service.ViewModels.UserViewModels;

namespace Service.Services.Interfaces
{
    public interface IUserService : IBaseService<User, UserViewModel>
    {
    }
}
