using Algolia.Search.Clients;
using Algolia.Search.Iterators;
using Algolia.Search.Models.Common;
using Algolia.Search.Models.Search;
using Letgo.DataAccess.Contexts;
using Letgo.DataAccess.Repositories.Abstract;
using Letgo.Entities.Abstract;
using Letgo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.DataAccess.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public SearchClient searchClient { get; set; }
        public SearchIndex searchIndex { get; set; }
        public BaseRepository()
        {
            searchClient = new SearchClient("M89XWI1ZIU", "2246c7f277bfcee950a221733290e265");
        }
        public async Task<BatchIndexingResponse> CreateAsync(string indexName, T input)
        {
            if (input == null)
            {
                throw new Exception("Nesne boş olamaz!");
            }
            else if (indexName == null)
            {
                throw new Exception("Index adı boş olamaz!");
            }
            searchIndex = searchClient.InitIndex(indexName);
            return await searchIndex.SaveObjectAsync(input);
        }
        public async Task<DeleteResponse> DeleteAsync(string indexName, string ObjectID)
        {
            if (ObjectID == null)
            {
                throw new Exception("ObjectID boş olamaz!");
            }
            else if (indexName == null)
            {
                throw new Exception("Index adı boş olamaz!");
            }
            searchIndex = searchClient.InitIndex(indexName);
            return await searchIndex.DeleteObjectAsync(ObjectID);
        }
        public async Task<BatchIndexingResponse> UpdateAsync(string indexName, T input)
        {
            if (input == null)
            {
                throw new Exception("Nesne boş olamaz!");
            }
            else if (indexName == null)
            {
                throw new Exception("Index adı boş olamaz!");
            }
            searchIndex = searchClient.InitIndex(indexName);
            return await searchIndex.SaveObjectAsync(input);
        }
        public async Task<T?> GetByIdAsync(string indexName, string ObjectID)
        {
            if (ObjectID == null)
            {
                throw new Exception("ObjectID boş olamaz!");
            }
            else if (indexName == null)
            {
                throw new Exception("Index adı boş olamaz!");
            }
            searchIndex = searchClient.InitIndex(indexName);
            return await searchIndex.GetObjectAsync<T>(ObjectID);
        }
        public async Task<IndexIterator<T>> GetAllAsync(string indexName)
        {
            if (indexName == null)
            {
                throw new Exception("Index adı boş olamaz!");
            }
            searchIndex = searchClient.InitIndex(indexName);
            IndexIterator<T> indexIterator = searchIndex.Browse<T>(new BrowseIndexQuery { });
            return indexIterator;
        }
    }
}
