using Letgo.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Letgo.WebUI.Models.DTO_s
{
    public class AdvertCreateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "İlan adı boş geçilemez!")]
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? Slug { get; set; }
        public string? StatusObjectID { get; set; }
        public AdvertStatus? Status { get; set; }
        public string? SellerId { get; set; }
        public User? Seller { get; set; }
        public hierarchicalCategories? hierarchicalCategories { get; set; }

    }
}
