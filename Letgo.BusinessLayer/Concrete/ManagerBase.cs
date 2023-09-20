using Letgo.BusinessLayer.Abstract;
using Letgo.DataAccess.Repositories.Abstract;
using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity
    {
        public readonly IBaseRepository<T> repository;

        public ManagerBase(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            return await repository.DeleteAsync(entity);
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter)
        {
            return await repository.GetAllAsync(filter);
        }

        public virtual async Task<IQueryable<T>>? GetAllIncludeAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include)
        {
            return await repository.GetAllIncludeAsync(filter, include);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public virtual async Task<int> CreateAsync(T entity)
        {
            return await repository.CreateAsync(entity);
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            return await repository.UpdateAsync(entity);
        }
    }
}
