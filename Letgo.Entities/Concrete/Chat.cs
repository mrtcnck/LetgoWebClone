using Letgo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.Entities.Concrete
{
    public class Chat : BaseEntity
    {
        public string AdvertObjectID { get; set; }
        public Advert? Advert { get; set; }
        public string SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public ICollection<ChatHistory>? ChatHistories { get; set; }
    }
}
