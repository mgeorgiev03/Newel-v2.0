using AutoMapper;
using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;
using Service.Services.Interfaces;
using Service.ViewModels.Authenticate;
using Service.ViewModels.UserViewModels;
using BCryptHelper = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public UserViewModel? Authenticate(AuthenticationViewModel model)
        {
            User? user = _userRepository.GetByEmail(model.Email);

            if (user == null)
                return null;
       
            if (BCryptHelper.Verify(model.Password, user.Password))
            
                return _mapper.Map<UserViewModel>(model);
            
            return null;
        }

        public void LogIn(AuthenticationViewModel model)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
