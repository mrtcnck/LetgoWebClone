using Algolia.Search.Iterators;
using Algolia.Search.Models.Common;
using Letgo.BusinessLayer.API.Abstract;
using Letgo.DataAccess.Repositories.Abstract;
using Letgo.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.API.Concrete
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
            var newName = entity.Name.Replace(" ", "+");

            var lvl0 = entity.Categories.Lvl0;
            var lvl1 = entity.Categories.Lvl0 + " > " + entity.Categories.Lvl1;
            var lvl2 = entity.Categories.Lvl0 + " > " + entity.Categories.Lvl1 + " > " + entity.Categories.Lvl2;
            entity.Categories.Lvl0 = lvl0;
            entity.Categories.Lvl1 = lvl1;
            entity.Categories.Lvl2 = lvl2;

            entity.Categories.UpdateDate = null;
            entity.Categories.CreationDate = null;
            entity.Categories.ObjectID = null;
            entity.Categories.AdvertObjectID = null;

            Advert advertModel = new Advert()
            {
                ObjectID = entity.ObjectID,
                Name = entity.Name,
                Image = entity.Image,
                Description = entity.Description,
                Price = entity.Price,
                Slug = newName + "+" + slugDesc,
                Categories = entity.Categories,
                SellerId = entity.SellerId,
                StatusObjectID = entity.StatusObjectID,
                CreationDate = entity.CreationDate,
                UpdateDate = DateTime.Now
            };

            return base.CreateAsync(indexName, advertModel);
        }

        public override Task<BatchIndexingResponse> UpdateAsync(string indexName, Advert entity)
        {
            var slugDesc = entity.Description.Replace(" ", "+");
            var newName = entity.Name.Replace(" ", "+");

            var lvl0 = entity.Categories.Lvl0;
            var lvl1 = entity.Categories.Lvl0 + " > " + entity.Categories.Lvl1;
            var lvl2 = entity.Categories.Lvl0 + " > " + entity.Categories.Lvl1 + " > " + entity.Categories.Lvl2;
            entity.Categories.Lvl0 = lvl0;
            entity.Categories.Lvl1 = lvl1;
            entity.Categories.Lvl2 = lvl2;

            entity.Categories.UpdateDate = null;
            entity.Categories.CreationDate = null;
            entity.Categories.ObjectID = null;
            entity.Categories.AdvertObjectID = null;

            Advert advertModel = new Advert()
            {
                ObjectID = entity.ObjectID,
                Name = entity.Name,
                Image = entity.Image,
                Description = entity.Description,
                Price = entity.Price,
                Slug = newName + "+" + slugDesc,
                Categories = entity.Categories,
                SellerId = entity.SellerId,
                StatusObjectID = entity.StatusObjectID,
                CreationDate = entity.CreationDate,
                UpdateDate = DateTime.Now
            };

            return base.UpdateAsync(indexName, advertModel);
        }
    }
}
