using API.Models;
using API.Services;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService service;
        public AccountController(IAuthenticationService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogInRequest logIn)
        {
            Guid id = await service.Authenticate(logIn);
            return Ok(id);
        }
    }
}
