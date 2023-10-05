using Algolia.Search.Iterators;
using Algolia.Search.Models.Common;
using Algolia.Search.Models.Search;
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
        public virtual async Task<BatchIndexingResponse> CreateAsync(string indexName, T entity)
        {
            return await repository.CreateAsync(indexName, entity);
        }
        public virtual async Task<DeleteResponse> DeleteAsync(string indexName, T entity)
        {
            return await repository.DeleteAsync(indexName, entity);
        }
        public virtual async Task<BatchIndexingResponse> UpdateAsync(string indexName, T entity)
        {
            return await repository.UpdateAsync(indexName, entity);
        }
        public virtual async Task<T?> GetByIdAsync(string indexName, string ObjectID)
        {
            return await repository.GetByIdAsync(indexName, ObjectID);
        }
        public virtual async Task<IndexIterator<T>> GetAllAsync(string indexName)
        {
            return await repository.GetAllAsync(indexName);
        }
    }
}
