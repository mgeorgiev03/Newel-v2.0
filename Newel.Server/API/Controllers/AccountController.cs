using API.Models;
using API.Services;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newel.Server.Repositories.IRepositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService service;
        private readonly IUserRepository repo;

        public AccountController(IAuthenticationService _service, IUserRepository userRepository)
        {
            service = _service;
            repo = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogInRequest logIn)
        {
            Guid id = await service.Authenticate(logIn);
            return Ok(id);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            try
            {
                await repo.DeleteAsync(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }

            return NoContent();
        }
    }
}
