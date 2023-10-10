using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Letgo.Entities.Concrete
{
    public class ChatHistory : BaseEntity
    {
        public string UserId{ get; set; }
        public string Message { get; set; }
        public string ChatObjectID { get; set; }
        public Chat? Chat { get; set; }
    }
}
