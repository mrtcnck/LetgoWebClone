using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.Entities.Concrete
{
    public class ReviewDetail : BaseEntity
    {
        public string EvaluatedId { get; set; }
        public User? Evaluated { get; set; }
        public string ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
