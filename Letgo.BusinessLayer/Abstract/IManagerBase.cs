using Algolia.Search.Iterators;
using Algolia.Search.Models.Common;
using Algolia.Search.Models.Search;
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
        Task<BatchIndexingResponse> CreateAsync(string indexName, T input);
        Task<DeleteResponse> DeleteAsync(string indexName, T input);
        Task<BatchIndexingResponse> UpdateAsync(string indexName, T input);

        Task<T?> GetByIdAsync(string indexName, string ObjectID);
        Task<IndexIterator<T>> GetAllAsync(string indexName);
    }
}
