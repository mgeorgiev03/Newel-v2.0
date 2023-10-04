using Microsoft.EntityFrameworkCore;
using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;

namespace Newel.Server.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(NewelDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await context.Set<User>().SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
