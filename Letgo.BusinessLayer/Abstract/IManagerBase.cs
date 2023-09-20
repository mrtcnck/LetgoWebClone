using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.Abstract
{
    public interface IManagerBase<T> where T : BaseEntity
    {
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter);
        Task<IQueryable<T>>? GetAllIncludeAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include);
    }
}
