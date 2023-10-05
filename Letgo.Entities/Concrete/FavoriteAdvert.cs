using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.Entities.Concrete
{
    public class FavoriteAdvert : BaseEntity
    {
        public string AdvertId { get; set; }
        public string UserId { get; set; }
    }
}
