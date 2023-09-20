using Letgo.DataAccess.Contexts;
using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.DataAccess.Repositories.Abstract
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        public SqlDbContext dbContext { get; set; }
        Task<int> CreateAsync(T input);
        Task<int> DeleteAsync(T input);
        Task<int> UpdateAsync(T input);

        Task<T?> GetByIdAsync(int id);
        Task<ICollection<T>>? GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<IQueryable<T>>? GetAllIncludeAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include);
    }
}
