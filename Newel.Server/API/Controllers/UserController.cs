using API.Models;
using API.Models.UserModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;
using BCryptHelper = BCrypt.Net.BCrypt;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repo;
        private readonly IMapper mapper;

        public UserController(IUserRepository _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] LogInRequest model)
        {
            User? user = repo.GetByEmail(model.Email);

            if (user == null)
                return NotFound();

            if (BCryptHelper.Verify(model.Password, user.Password))
                return Ok(mapper.Map<UserResponseModel>(model));

            return BadRequest("Email address or password don't match");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassword([FromRoute] Guid id, [FromBody] UserUpdatePasswordRequest model)
        {
            var user = await repo.GetByIdAsync(id);


            if (!BCryptHelper.Verify(model.OldPassword, user.Password))
                throw new ArgumentException("Invalid password!");


            if (model.OldPassword == model.NewPassword)
                throw new ArgumentException("NewPassword is the same as OldPassword!");


            user.Password = BCryptHelper.HashPassword(model.NewPassword, BCryptHelper.GenerateSalt());

            var entity = mapper.Map<User>(user);

            await repo.UpdateAsync(entity);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
        
            var user = mapper.Map<User>(model);
            var createUser = await repo.CreateAsync(user);

            return Ok(createUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = mapper.Map<User>(model);
            user.Id = id;

            try
            {
                await repo.UpdateAsync(user);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await repo.GetAllAsync();

            var models = mapper.Map<List<UserResponseModel>>(users);   

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await repo.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            var model = mapper.Map<UserResponseModel>(user);

            return Ok(model);
        }
    }
}
