using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StarWarsLegionCompanion.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsLegionCompanion.LogHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var context = new DataContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                
                context.SaveChanges();

            }
        }
        
    }
}

//public class Unit
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public List<Weapon> Weapons { get; set; } = new List<Weapon>();
//}
//public class Weapon
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public List<Unit> Units { get; set; } = new List<Unit>();
//    public List<AttackDie> AttackDie { get; set; } = new List<AttackDie>();

//}
//public class AttackDie
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public int Value { get; set; }
//    public List<Weapon> Weapons { get; set; } = new List<Weapon>();
//}

public class DataContext : DbContext
{
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<Upgrade> Upgrades { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Weapon> Weapons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
        => builder
        .LogTo(Console.WriteLine, LogLevel.Information)
        .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StarWarsLegion;Trusted_Connection=True;");

}

