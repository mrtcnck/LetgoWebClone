using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.Db.Abstract
{
    public interface IManagerBaseDb<T> where T : BaseEntity
    {
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<T> GetById(string id);
        Task<ICollection<T>> GetAll(Expression<Func<T, bool>>? filter);
        Task<IQueryable<T>>? GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include);
    }
}
