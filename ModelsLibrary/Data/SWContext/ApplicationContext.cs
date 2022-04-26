using Microsoft.EntityFrameworkCore;
using UtilityLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibrary.Data.SWContext
{
#pragma warning disable CS1591

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Army> Armies { get; set; }
        public DbSet<ChosenCommand> ChosenCommands { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Player> Palyers { get; set; }
    }
#pragma warning restore CS1591
}
