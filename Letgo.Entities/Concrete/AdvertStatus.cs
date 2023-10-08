using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.Entities.Concrete
{
    public class AdvertStatus : BaseEntity
    {
        public string AdvertObjectID { get; set; }
        public Advert Advert { get; set; }
        public bool IsOnAir { get; set; }
        public bool IsSold { get; set; }
        public bool IsRemove { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDenied { get; set; }
        public bool IsModify { get; set; }
    }
}
