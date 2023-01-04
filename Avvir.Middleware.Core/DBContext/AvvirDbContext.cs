using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avvir.Middleware.Core.DBContext
{
    public class AvvirDbContext : DbContext
    {
        public AvvirDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=avvir-dev.vikklein.com;Initial Catalog=Avvir;User ID=Eugene;Password=Gesha73");
        }
    }
}
