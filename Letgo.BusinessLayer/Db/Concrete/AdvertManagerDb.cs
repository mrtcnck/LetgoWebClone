using Letgo.BusinessLayer.Db.Abstract;
using Letgo.DataAccess.DbRepositories.Abstract;
using Letgo.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.Db.Concrete
{
    public class AdvertManagerDb : ManagerBaseDb<Advert>, IAdvertManagerDb
    {
        public AdvertManagerDb(IAdvertRepositoryDb repository) : base(repository)
        {
        }

        public override async Task<int> Create(Advert entity)
        {
            var newName = entity.Name.ToLower().Replace(" ", "+");
            var newDesc = entity.Description.ToLower().Replace(" ", "+");
            entity.Slug = newName + "+" + newDesc;

            return await base.Create(entity);
        }
        public override Task<int> Update(Advert entity)
        {
            var newName = entity.Name.ToLower().Replace(" ", "+");
            var newDesc = entity.Description.ToLower().Replace(" ", "+");
            entity.Slug = newName + "+" + newDesc + "+" + entity.ObjectID.Split("-")[0];

            return base.Update(entity);
        }
    }
}
