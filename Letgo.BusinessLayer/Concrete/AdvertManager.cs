using Letgo.BusinessLayer.Abstract;
using Letgo.DataAccess.Repositories.Abstract;
using Letgo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.BusinessLayer.Concrete
{
    public class AdvertManager : ManagerBase<Advert>, IAdvertManager
    {
        public AdvertManager(IAdvertRepository repository) : base(repository)
        {
        }
    }
}
