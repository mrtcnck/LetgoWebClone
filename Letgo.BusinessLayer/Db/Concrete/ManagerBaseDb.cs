using Letgo.BusinessLayer.API.Abstract;
using Letgo.BusinessLayer.Db.Abstract;
using Letgo.DataAccess.DbRepositories.Abstract;
using Letgo.DataAccess.Repositories.Abstract;
using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.Db.Concrete
{
    public class ManagerBaseDb<T> : IManagerBaseDb<T> where T : BaseEntity
    {
        public readonly IBaseRepositoryDb<T> repository;

        public ManagerBaseDb(IBaseRepositoryDb<T> repository)
        {
            this.repository = repository;

        }

        public virtual async Task<int> Delete(T entity)
        {
            return await repository.Delete(entity);
        }

        public virtual async Task<ICollection<T>> GetAll(Expression<Func<T, bool>>? filter)
        {
            return await repository.GetAll(filter);
        }

        public virtual async Task<IQueryable<T>>? GetAllInclude(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include)
        {
            return await repository.GetAllInclude(filter, include);
        }

        public virtual async Task<T> GetById(string id)
        {
            return await repository.GetById(id);
        }

        public virtual async Task<int> Create(T entity)
        {
            return await repository.Create(entity);
        }

        public virtual async Task<int> Update(T entity)
        {
            return await repository.Update(entity);
        }
    }
}
