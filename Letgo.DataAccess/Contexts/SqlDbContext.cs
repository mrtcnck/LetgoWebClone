using Letgo.Entities.Abstract;
using Letgo.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.DataAccess.Contexts
{
    public class SqlDbContext : IdentityDbContext<User>
    {
        public SqlDbContext()
        {
            
        }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MERTCAN\MSSQLSERVER01;Database=LetgoWebClone;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(be => be.UpdateDate).CurrentValue = DateTime.Now;
                    entry.Property(be => be.CreationDate).CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property(be => be.UpdateDate).CurrentValue = DateTime.Now;
                    entry.Property(be => be.CreationDate).IsModified = false;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
