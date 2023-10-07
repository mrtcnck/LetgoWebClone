using Algolia.Search.Iterators;
using Algolia.Search.Models.Common;
using Letgo.BusinessLayer.Abstract;
using Letgo.DataAccess.Repositories.Abstract;
using Letgo.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> userManager;

        public AdvertManager(IAdvertRepository repository, IAdvertStatusManager advertStatusManager, UserManager<User> userManager) : base(repository)
        {
            this.advertStatusManager = advertStatusManager;
            this.userManager = userManager;
        }

        public override Task<BatchIndexingResponse> CreateAsync(string indexName, Advert entity)
        {
            var slugDesc = entity.Description.Replace(" ", "+");

            var lvl0 = entity.hierarchicalCategories.Lvl0;
            var lvl1 = entity.hierarchicalCategories.Lvl0 + " > " + entity.hierarchicalCategories.Lvl1;
            var lvl2 = entity.hierarchicalCategories.Lvl0 + " > " + entity.hierarchicalCategories.Lvl1 + " > " + entity.hierarchicalCategories.Lvl2;
            entity.hierarchicalCategories = new hierarchicalCategories { Lvl0 = lvl0, Lvl1 = lvl1, Lvl2 = lvl2 };

            var advertStatus = advertStatusManager.CreateAsync("advertStatues", new AdvertStatus());

            Advert advertModel = new Advert()
            {
                ObjectID = Guid.NewGuid().ToString(),
                Name = entity.Name,
                Image = entity.Image,
                Description = entity.Description,
                Price = entity.Price,
                Slug = entity.Name + "+" + slugDesc,
                hierarchicalCategories = entity.hierarchicalCategories,
                SellerId = entity.SellerId,
                StatusId = advertStatus.Id.ToString(),
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            return base.CreateAsync(indexName, advertModel);
        }

        public override Task<BatchIndexingResponse> UpdateAsync(string indexName, Advert entity)
        {
            var slugDesc = entity.Description.Replace(" ", "+");

            var lvl0 = entity.hierarchicalCategories.Lvl0;
            var lvl1 = entity.hierarchicalCategories.Lvl1;
            var lvl2 = entity.hierarchicalCategories.Lvl2;
            entity.hierarchicalCategories = new hierarchicalCategories { Lvl0 = lvl0, Lvl1 = lvl1, Lvl2 = lvl2 };

            //var advertStatus = advertStatusManager.GetByIdAsync("advertStatues", entity.StatusId);

            //AdvertStatus advertStatusModel = new()
            //{
            //    ObjectID = advertStatus.Result.ObjectID,
            //    AdvertId = entity.ObjectID,
            //    IsOnAir = false,
            //    IsSold = false,
            //    IsRemove = false,
            //    IsApproved = false,
            //    IsDenied = false,
            //    IsModify = true
            //};

            //advertStatusManager.UpdateAsync("advertStatues", advertStatusModel);
            
            Advert advertModel = new Advert()
            {
                ObjectID = entity.ObjectID,
                Name = entity.Name,
                Image = entity.Image,
                Description = entity.Description,
                Price = entity.Price,
                Slug = entity.Name + "+" + slugDesc,
                hierarchicalCategories = entity.hierarchicalCategories,
                SellerId = entity.SellerId,
                StatusId = "1",
                CreationDate = entity.CreationDate,
                UpdateDate = DateTime.Now
            };

            return base.UpdateAsync(indexName, advertModel);
        }
    }
}
