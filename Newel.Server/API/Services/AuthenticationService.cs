using API.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;
using BCryptHelper = BCrypt.Net.BCrypt;

namespace API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository repo;
        public AuthenticationService(IUserRepository _repo)
        {
            repo = _repo;
        }

        public async Task<Guid> Authenticate(LogInRequest model)
        {
            User? user = await repo.GetByEmail(model.Email);

            if (user == null)
            {
                Console.WriteLine("No user found");
                throw new ArgumentException("No user found");
            }

            if (BCryptHelper.Verify(model.Password, user.Password))
                return user.Id;

            Console.WriteLine("Email address or password don't match");
            throw new ArgumentException("Email address or password don't match");
        }
    }
}
