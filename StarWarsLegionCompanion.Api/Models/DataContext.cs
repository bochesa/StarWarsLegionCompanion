using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<RangeType> RangeTypes { get; set; }
        public DbSet<AttackDie> AttackDie { get; set; }
        public DbSet<AttackSurge> AttackSurges { get; set; }
        public DbSet<UnitType> UnitTypes{ get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Army> ArmyLists { get; set; }
        public DbSet<Player> Players { get; set; }

        //public DbSet<Upgrade> Upgrades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
        }
    }
}
