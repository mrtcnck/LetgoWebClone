using Letgo.DataAccess.Contexts;
using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.DataAccess.DbRepositories.Abstract
{
    public interface IBaseRepositoryDb<T> where T : BaseEntity
    {
        public SqlDbContext dbContext { get; set; }
        Task<int> Create(T input);
        Task<int> Delete(T input);
        Task<int> Update(T input);

        Task<T?> GetById(string id);
        Task<ICollection<T>>? GetAll(Expression<Func<T, bool>> filter = null);
        Task<IQueryable<T>>? GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include);
    }
}
