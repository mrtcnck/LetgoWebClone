using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.Entities.Concrete
{
    public class FavoriteProduct : BaseEntity
    {
        public string AdvertId { get; set; }
        public Advert? Advert { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}
