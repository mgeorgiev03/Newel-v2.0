using API.Models.ListModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IToDoListRepository repo;
        private readonly IMapper mapper;

        public ListController(IToDoListRepository _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateList([FromBody] ListRequestModel model)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var list = mapper.Map<ToDoList>(model);
            var id = await repo.CreateAsync(list); 

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateList([FromRoute] Guid id, [FromBody] ListRequestModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var list = mapper.Map<ToDoList>(model);
            list.Id = id;

            try
            {
                await repo.UpdateAsync(list);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList([FromRoute] Guid id)
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
        public async Task<IActionResult> GetList([FromRoute] Guid id)
        {
            var list = await repo.GetByIdAsync(id);

            if (list == null)
                return NotFound();

            var model = mapper.Map<ListResponseModel>(list);

            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lists = await repo.GetAllAsync();

            var models = mapper.Map<List<ToDoList>>(lists);

            return Ok(models);
        }
    }
}
