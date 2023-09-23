using Microsoft.EntityFrameworkCore;
using Newel.Server.Model;
using Newel.Server.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Newel.Server.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        internal readonly NewelDbContext context;
        public BaseRepository(NewelDbContext _context)
        {
            context = _context;
        }

        public async Task CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null) 
                throw new ArgumentException($"There is no such {typeof(T)} with id: {id}");


            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            var set = context.Set<T>().AsQueryable();

            if (filter != null)
                set = set.Where(filter);

            return await set.ToListAsync();
        }

        public async ValueTask<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
                throw new ArgumentException($"No such {typeof(T)} with id: {entity.Id}");


            context.Entry(dbEntity).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
        }
    }
}
