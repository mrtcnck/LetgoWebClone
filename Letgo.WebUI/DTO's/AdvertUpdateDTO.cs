using Letgo.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Letgo.WebUI.DTO_s
{
    public class AdvertUpdateDTO
    {
        public string ObjectID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "İlan adı boş geçilemez!")]
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? Slug { get; set; }
        public string? StatusId { get; set; }
        public string? SellerId { get; set; }
        public hierarchicalCategories? hierarchicalCategories { get; set; }
    }
}

