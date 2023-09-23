using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;

namespace Newel.Server.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(NewelDbContext context) : base(context)
        {
        }

        public User? GetByEmail(string email)
        {
            return context.Set<User>().SingleOrDefault(u => u.Email == email);
        }
    }
}
