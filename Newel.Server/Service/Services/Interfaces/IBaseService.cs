using Newel.Server.Model;
using System.Linq.Expressions;

namespace Service.Services.Interfaces
{
    public interface IBaseService<TEntity, TViewModel>
        where TEntity : BaseEntity
        where TViewModel : class
    {
        Task CreateAsync(TViewModel model);
        Task DeleteAsync(Guid id);
        ValueTask<TViewModel> GetByIdAsync(Guid id);
        Task<TEntity> OnBeforeCreate(TViewModel model);
        Task<TEntity> OnBeforeUpdate(TViewModel model);
        Task Update(TViewModel model);
        Task<List<TViewModel>> GetAllAsync(Expression<Func<TViewModel, bool>>? filter = null);
    }
}
