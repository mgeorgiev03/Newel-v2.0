using Service.ViewModels.Authenticate;
using Service.ViewModels.UserViewModels;

namespace Service.Services.Interfaces
{
    public interface IAuthenticationService
    {
        UserViewModel? Authenticate(AuthenticationViewModel model);
        void LogIn(AuthenticationViewModel model);//, HttpContext context);
        void LogOut();//, HttpContext context);
    }
}
