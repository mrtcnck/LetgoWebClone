using Letgo.Entities.Abstract;

namespace Letgo.Entities.Concrete
{
    public class hierarchicalCategories
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Lvl0 { get; set; }
        public string? Lvl1 { get; set; }
        public string? Lvl2 { get; set; }
    }
}