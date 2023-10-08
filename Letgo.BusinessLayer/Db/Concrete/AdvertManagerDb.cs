using Letgo.BusinessLayer.Db.Abstract;
using Letgo.DataAccess.DbRepositories.Abstract;
using Letgo.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.Db.Concrete
{
    public class AdvertManagerDb : ManagerBaseDb<Advert>, IAdvertManagerDb
    {
        private readonly IAdvertStatusManagerDb advertStatusManagerDb;

        public AdvertManagerDb(IAdvertRepositoryDb repository, IAdvertStatusManagerDb advertStatusManagerDb) : base(repository)
        {
            this.advertStatusManagerDb = advertStatusManagerDb;
        }

        public override Task<int> Create(Advert entity)
        {
            AdvertStatus advertStatus = new();
            advertStatusManagerDb.Create(advertStatus);
            entity.StatusObjectID = advertStatus.ObjectID;
            var newDesc = entity.Description.Replace(" ", "+");
            entity.Slug = entity.Name + "+" + newDesc;
            return base.Create(entity);
        }
    }
}
