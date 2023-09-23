using Newel.Server.Model;
using Service.ViewModels.TaskViewModels;

namespace Service.Services.Interfaces
{
    public interface IToDoItemService : IBaseService<ToDoItem, ToDoItemViewModel>
    {
    }
}
