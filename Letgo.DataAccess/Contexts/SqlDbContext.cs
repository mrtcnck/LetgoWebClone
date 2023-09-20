using Letgo.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letgo.DataAccess.Contexts
{
    public class SqlDbContext : IdentityDbContext<User>
    {
    }
}
