using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;

namespace Newel.Server.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(NewelDbContext _context) : base(_context)
        {
        }
    }
}
