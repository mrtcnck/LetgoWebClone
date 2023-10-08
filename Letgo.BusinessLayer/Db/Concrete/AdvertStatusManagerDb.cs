using Letgo.BusinessLayer.API.Concrete;
using Letgo.BusinessLayer.Db.Abstract;
using Letgo.DataAccess.DbRepositories.Abstract;
using Letgo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.Db.Concrete
{
    public class AdvertStatusManagerDb : ManagerBaseDb<AdvertStatus>, IAdvertStatusManagerDb
    {

        public AdvertStatusManagerDb(IAdvertStatusRepositoryDb repository) : base(repository)
        {
        }
    }
}
