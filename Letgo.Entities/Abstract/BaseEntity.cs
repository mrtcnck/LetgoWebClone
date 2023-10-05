using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.Entities.Abstract
{
    public class BaseEntity
    {
        public string ObjectID { get; set; }
        public DateTime CreationDate{ get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
