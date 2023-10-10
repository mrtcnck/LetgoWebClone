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
    public class ChatConfig : BaseConfig<Chat>
    {
        public override void Configure(EntityTypeBuilder<Chat> builder)
        {
            base.Configure(builder);
        }
    }
}
