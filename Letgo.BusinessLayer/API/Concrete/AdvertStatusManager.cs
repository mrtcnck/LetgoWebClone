using Algolia.Search.Iterators;
using Algolia.Search.Models.Common;
using Letgo.BusinessLayer.API.Abstract;
using Letgo.DataAccess.Repositories.Abstract;
using Letgo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.API.Concrete
{
    public class AdvertStatusManager : ManagerBase<AdvertStatus>, IAdvertStatusManager
    {
        public AdvertStatusManager(IAdvertStatusRepository repository) : base(repository)
        {
        }
        public override Task<BatchIndexingResponse> CreateAsync(string indexName, AdvertStatus entity)
        {
            AdvertStatus advertStatusModel = new()
            {
                IsOnAir = false,
                IsSold = false,
                IsRemove = false,
                IsApproved = false,
                IsDenied = false,
                IsModify = false
            };

            return base.CreateAsync(indexName, advertStatusModel);
        }
    }
}
