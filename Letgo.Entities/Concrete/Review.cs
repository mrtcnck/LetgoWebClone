using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.Entities.Concrete
{
    public class Review : BaseEntity
    {
        public int Point { get; set; } /*1 ile 5 arası olacak*/
        public string AssessedId { get; set; }
        public User? Assessed { get; set; }
        public string EvaluatedId { get; set; }
        public User? Evaluated { get; set; }
    }
}
