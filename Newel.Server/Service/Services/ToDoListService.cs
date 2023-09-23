using AutoMapper;
using Newel.Server.Model;
using Newel.Server.Repositories;
using Service.Services.Interfaces;
using Service.ViewModels.ListViewModels;

namespace Service.Services
{
    public class ToDoListService : BaseService<ToDoList, ToDoListViewModel, ToDoListRepository>, IToDoListService
    {
        public ToDoListService(ToDoListRepository _repository, IMapper _mapper) : base(_repository, _mapper)
        {
        }
    }
}
