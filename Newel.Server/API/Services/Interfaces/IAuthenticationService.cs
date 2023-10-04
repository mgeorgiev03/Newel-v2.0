using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<Guid> Authenticate(LogInRequest model);
    }
}
