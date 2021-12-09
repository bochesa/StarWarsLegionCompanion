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
            //Database.EnsureCreated();
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Army> ArmyLists { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<RangeType> RangeTypes { get; set; }
        public DbSet<AttackDie> AttackDie { get; set; }
        public DbSet<AttackSurge> AttackSurges { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Upgrade> Upgrades { get; set; }
        public DbSet<UpgradeCategory> UpgradeCategories { get; set; }

        public DbSet<ChosenUnit> ChosenUnits { get; set; }
        public DbSet<ChosenUpgrade> ChosenUpgrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            //modelBuilder
            //    .Entity<Unit>()
            //    .HasMany(p => p.Armies)
            //    .WithMany(p => p.Units)
            //    .UsingEntity(j => j.ToTable("ArmyUnits"));

            //modelBuilder.Entity<Unit>()
            //.HasMany(p => p.Armies)
            //.WithMany(p => p.Units)
            //.UsingEntity<ArmyUnit>(
            //    j => j
            //        .HasOne(pt => pt.Army)
            //        .WithMany(t => t.ArmyUnits)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasForeignKey(pt => pt.ArmyId)
            //        .IsRequired(),
            //    j => j
            //        .HasOne(pt => pt.Unit)
            //        .WithMany(p => p.ArmyUnits)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasForeignKey(pt => pt.UnitId)
            //        .IsRequired(),
            //    j =>
            //    {
            //        j.Property(pt => pt.NumberOfUnits).HasDefaultValue(1);
            //        j.HasKey(t => new { t.ArmyId, t.UnitId });
            //    });


        }
    }
}
