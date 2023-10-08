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
    public class AdvertConfig : BaseConfig<Advert>
    {
        public override void Configure(EntityTypeBuilder<Advert> builder)
        {
            base.Configure(builder);
            builder.HasIndex(a => a.Slug).IsUnique();
            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(a => a.Price).HasDefaultValue(0.00);
            builder.HasOne(a => a.Categories).WithOne(c => c.Advert).HasForeignKey<hierarchicalCategories>(c => c.AdvertObjectID);
        }
    }
}
