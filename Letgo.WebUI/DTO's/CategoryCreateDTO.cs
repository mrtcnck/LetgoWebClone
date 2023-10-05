using System.ComponentModel.DataAnnotations;

namespace Letgo.WebUI.DTO_s
{
    public class CategoryCreateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kategori adı boş geçilemez!")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kategori açıklaması boş geçilemez!")]
        public string? Description { get; set; }
    }
}
