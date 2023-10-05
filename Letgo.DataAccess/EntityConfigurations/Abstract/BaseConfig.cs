using Letgo.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.DataAccess.EntityConfigurations.Abstract
{
    public class BaseConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(t => t.ObjectID);
            builder.Property(t => t.ObjectID).HasDefaultValue(Guid.NewGuid().ToString());
            builder.HasIndex(t => t.ObjectID).IsUnique();
        }
    }
}
