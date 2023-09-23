using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;

namespace Newel.Server.Repositories
{
    public class ToDoItemRepository : BaseRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(NewelDbContext _context) : base(_context)
        {
        }
    }
}
