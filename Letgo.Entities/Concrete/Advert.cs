using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.Entities.Concrete
{
    public class Advert : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string Slug { get; set; }
        public string AdvertStatusId { get; set; }
        public string SellerId { get; set; }
        public string CategoryId { get; set; }
    }
}
