using Newel.Server.Model;
using System.Linq.Expressions;

namespace Newel.Server.Repositories.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<Guid> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(Guid id);
        public ValueTask<T> GetByIdAsync(Guid id);
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    }
}
