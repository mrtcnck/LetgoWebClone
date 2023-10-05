using Algolia.Search.Iterators;
using Algolia.Search.Models.Common;
using Letgo.BusinessLayer.Abstract;
using Letgo.DataAccess.Repositories.Abstract;
using Letgo.Entities.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.Concrete
{
    public class AdvertManager : ManagerBase<Advert>, IAdvertManager
    {
        private readonly IAdvertStatusManager advertStatusManager;

        public AdvertManager(IAdvertRepository repository, IAdvertStatusManager advertStatusManager) : base(repository)
        {
            this.advertStatusManager = advertStatusManager;
        }

        public override Task<BatchIndexingResponse> CreateAsync(string indexName, Advert entity)
        {
            var slugDesc = entity.Description.Replace(" ", "-");

            var advertStatus = advertStatusManager.CreateAsync("advertStatues", new AdvertStatus());

            Advert advertModel = new Advert()
            {
                ObjectID = Guid.NewGuid().ToString(),
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Slug = entity.Name + "-" + slugDesc,
                CategoryId = entity.CategoryId,
                SellerId = entity.SellerId,
                AdvertStatusId = advertStatus.Id.ToString(),
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            return base.CreateAsync(indexName, advertModel);
        }

        public override Task<BatchIndexingResponse> UpdateAsync(string indexName, Advert entity)
        {
            var slugDesc = entity.Description.Replace(" ", "-");

            var advertStatus = advertStatusManager.GetByIdAsync("advertStatues", entity.AdvertStatusId);

            AdvertStatus advertStatusModel = new()
            {
                ObjectID = advertStatus.Result.ObjectID,
                AdvertId = entity.ObjectID,
                IsOnAir = false,
                IsSold = false,
                IsRemove = false,
                IsApproved = false,
                IsDenied = false,
                IsModify = true
            };

            advertStatusManager.UpdateAsync("advertStatues", advertStatusModel);
            
            Advert advertModel = new Advert()
            {
                ObjectID = entity.ObjectID,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Slug = entity.Name + "-" + slugDesc,
                CategoryId = entity.CategoryId,
                SellerId = entity.SellerId,
                AdvertStatusId = advertStatus.Id.ToString(),
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            return base.UpdateAsync(indexName, advertModel);
        }
    }
}
