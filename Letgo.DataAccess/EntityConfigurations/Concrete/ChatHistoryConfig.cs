using Letgo.DataAccess.EntityConfigurations.Abstract;
using Letgo.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.DataAccess.EntityConfigurations.Concrete
{
    public class ChatHistoryConfig : BaseConfig<ChatHistory>
    {
        public override void Configure(EntityTypeBuilder<ChatHistory> builder)
        {

            base.Configure(builder);
            //builder.HasOne(c => c.Advert).WithOne(a => a.ChatHistory).HasForeignKey<Advert>(a => a.ChatHistoryObjectID);
        }
    }
}
