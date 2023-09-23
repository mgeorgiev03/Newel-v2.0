using Newel.Server.Model;
using Service.ViewModels.ListViewModels;

namespace Service.Services.Interfaces
{
    public interface IToDoListService : IBaseService<ToDoList, ToDoListViewModel>
    {
    }
}
