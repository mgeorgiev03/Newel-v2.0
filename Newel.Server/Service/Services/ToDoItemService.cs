using AutoMapper;
using Newel.Server.Model;
using Newel.Server.Repositories;
using Service.Services.Interfaces;
using Service.ViewModels.TaskViewModels;

namespace Service.Services
{
    public class ToDoItemService : BaseService<ToDoItem, ToDoItemViewModel, ToDoItemRepository>, IToDoItemService
    {
        public ToDoItemService(ToDoItemRepository _repository, IMapper _mapper) : base(_repository, _mapper)
        {
        }
    }
}
