using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;

namespace Newel.Server.Repositories
{
    public class ToDoListRepository : BaseRepository<ToDoList>, IToDoListRepository
    {
        public ToDoListRepository(NewelDbContext _context) : base(_context)
        {
        }

        public ValueTask<ToDoList> GetByName(string name)
        {
            return context.FindAsync<ToDoList>(name);
        }
    }
}
