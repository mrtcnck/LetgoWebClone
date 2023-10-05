using Letgo.DataAccess.EntityConfigurations.Abstract;
using Letgo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.DataAccess.EntityConfigurations.Concrete
{
    public class ReviewConfig : BaseConfig<Review>
    {
        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);
            builder.Property(r => r.Point).HasDefaultValue(1);
        }
    }
}
