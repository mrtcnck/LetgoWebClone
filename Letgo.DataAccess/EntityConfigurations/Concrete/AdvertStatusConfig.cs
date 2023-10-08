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
    public class AdvertStatusConfig: BaseConfig<AdvertStatus>
    {
        public override void Configure(EntityTypeBuilder<AdvertStatus> builder)
        {
            base.Configure(builder);
            builder.Property(AS => AS.IsOnAir).HasDefaultValue(false);
            builder.Property(AS => AS.IsSold).HasDefaultValue(false);
            builder.Property(AS => AS.IsRemove).HasDefaultValue(false);
            builder.Property(AS => AS.IsApproved).HasDefaultValue(false);
            builder.Property(AS => AS.IsDenied).HasDefaultValue(false);
            builder.HasOne(AS => AS.Advert).WithOne(A => A.Status).HasForeignKey<Advert>(a => a.StatusObjectID);
        }
    }
}
