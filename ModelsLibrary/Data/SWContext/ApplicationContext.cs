using Microsoft.EntityFrameworkCore;
using UtilityLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Data.SWContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Army> Armies { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }

    }
}
