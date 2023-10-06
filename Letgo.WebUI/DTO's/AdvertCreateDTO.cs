using Letgo.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Letgo.WebUI.Models.DTO_s
{
    public class AdvertCreateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "İlan adı boş geçilemez!")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Resim alanı boş geçilemez!")]
        public string Image { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? Slug { get; set; }
        public string? StatusId { get; set; }
        public string? SellerId { get; set; }
        public string? CategoryId { get; set; }
    }
}
