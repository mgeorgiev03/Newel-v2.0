using Newel.Server.Model;

namespace Newel.Server.Repositories.IRepositories
{
    public interface IToDoListRepository : IBaseRepository<ToDoList>
    {
        public ValueTask<ToDoList> GetByName(string name);
    }
}
