using Microsoft.AspNetCore.Identity;

namespace Letgo.Entities.Concrete
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public ICollection<Advert>? Adverts { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}