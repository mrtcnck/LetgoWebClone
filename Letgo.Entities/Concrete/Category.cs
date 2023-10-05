using Letgo.Entities.Abstract;

namespace Letgo.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}