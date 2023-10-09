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

        [HttpPatch("{id}")]
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

            model.Password = BCryptHelper.HashPassword(model.Password, BCryptHelper.GenerateSalt()); 

            var user = mapper.Map<User>(model);
            var id = await repo.CreateAsync(user);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserRequestModel model)
        {
            Console.WriteLine("hmmm1");
            var user = mapper.Map<User>(model);
            //User user = new User();
            user.Id = id;
            user.Name = model.Name;
            user.Email = model.Email;

            //need to get password of entity because this request won't change it and wont have a form for it
            //hope this is enough
            User entity = await repo.GetByIdAsync(id);
            model.Password = entity.Password;

            try
            {
                Console.WriteLine("hmmm");
                await repo.UpdateAsync(user);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        //{
        //    try
        //    {
        //        await repo.DeleteAsync(id);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(ex);
        //    }

        //    return NoContent();
        //}

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

        //[HttpGet("{email}")]
        //public async Task<IActionResult> GetByEmail([FromRoute] string email)
        //{
        //    var user = await repo.GetByEmail(email);

        //    if (user == null)
        //        return NotFound();

        //    var model = mapper.Map<UserResponseModel>(user);

        //    return Ok(model);
        //}
    }
}
