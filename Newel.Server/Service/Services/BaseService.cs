using AutoMapper;
using Newel.Server.Model;
using Newel.Server.Repositories;
using Service.Services.Interfaces;
using System.Linq.Expressions;

namespace Service.Services
{
    public class BaseService<TEntity, TViewModel, TRepository> : IBaseService<TEntity, TViewModel>
        where TEntity : BaseEntity
        where TViewModel : class
        where TRepository : BaseRepository<TEntity>
    {
        private readonly TRepository repository;
        private readonly IMapper mapper;
        public BaseService(TRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }


        public virtual async Task CreateAsync(TViewModel model)
        {
            var entity = await OnBeforeCreate(model);

            await repository.CreateAsync(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public virtual async Task<List<TViewModel>> GetAllAsync(Expression<Func<TViewModel, bool>>? filter = null)
        {
            var expression = mapper.Map<Expression<Func<TEntity, bool>>?>(filter);

            var result = await repository.GetAllAsync(expression);

            return mapper.Map<List<TViewModel>>(result);
        }

        public virtual async ValueTask<TViewModel> GetByIdAsync(Guid id)
        {
            var entity = await repository.GetByIdAsync(id);

            return mapper.Map<TViewModel>(entity);
        }   

        public virtual async Task<TEntity> OnBeforeCreate(TViewModel model)
        {
            return mapper.Map<TEntity>(model);
        }

        public virtual async Task<TEntity> OnBeforeUpdate(TViewModel model)
        {
            return mapper.Map<TEntity>(model);
        }

        public virtual async Task Update(TViewModel model)
        {
            var entity = await OnBeforeUpdate(model);

            await repository.UpdateAsync(entity);
        }
    }
}
