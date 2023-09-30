using API.Models.TaskModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IToDoItemRepository repo;
        private readonly IMapper mapper;

        public TaskController(IToDoItemRepository _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = mapper.Map<ToDoItem>(model);
            var id = await repo.CreateAsync(task);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromRoute] Guid id, [FromBody] TaskRequestModel model)
        {
            var task = mapper.Map<ToDoItem>(model);

            try
            {
                await repo.UpdateAsync(task);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute] Guid id)
        {
            try
            {
                await repo.DeleteAsync(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask([FromRoute] Guid id)
        {
            var task = await repo.GetByIdAsync(id);

            if (!ModelState.IsValid)
                return NotFound();

            var model = mapper.Map<TaskResponseModel>(task);

            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await repo.GetAllAsync();

            var models = mapper.Map<List<TaskResponseModel>>(tasks);

            return Ok(models);
        }
    }
}
