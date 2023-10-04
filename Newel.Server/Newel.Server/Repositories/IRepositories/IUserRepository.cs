using Newel.Server.Model;

namespace Newel.Server.Repositories.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmail(string email);
    }
}
