using Microsoft.AspNet.Identity.EntityFramework;

namespace Letgo.Entities.Concrete
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Advert> Adverts { get; set; }
        public ICollection<Review> Assesseds { get; set; }
        public ICollection<Review> Evaluateds { get; set; }
    }
}