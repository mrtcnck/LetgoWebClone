using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.Entities.Concrete
{
    public class Advert : BaseEntity
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? Slug { get; set; }
        public string? StatusObjectID { get; set; }
        public AdvertStatus? Status { get; set; }
        public string? SellerId { get; set; }
        public User? Seller { get; set; }
        public string hierarchicalCategoriesId { get; set; }
        public hierarchicalCategories? hierarchicalCategories { get; set; }
    }
}
