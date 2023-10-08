using Letgo.Entities.Abstract;

namespace Letgo.Entities.Concrete
{
    public class hierarchicalCategories : BaseEntity
    {
        public string Lvl0 { get; set; }
        public string? Lvl1 { get; set; }
        public string? Lvl2 { get; set; }
        public string AdvertObjectID { get; set; }
        public Advert? Advert { get; set; }
    }
}