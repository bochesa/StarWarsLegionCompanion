using System.Collections.Generic;

namespace UtilityLibrary.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit? Affiliation { get; set; } = null;
        public int Pips { get; set; }
        public string Text { get; set; }
        public string UnitActivated { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
        public virtual ICollection<UpgradeOption> UpgradeOptions { get; set; }

    }

    //public class RangeType
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    [NotMapped, JsonIgnore]
    //    public virtual List<Weapon> Weapons { get; set; }
    //}
    //public class Faction
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    [NotMapped, JsonIgnore]
    //    public virtual List<Unit> Units { get; set; }
    //}

    //public class AttackSurge
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    [NotMapped, JsonIgnore]
    //    public virtual List<Unit> Units { get; set; }

    //}
    //public class UnitType
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    [NotMapped, JsonIgnore]
    //    public virtual List<Unit> Units { get; set; }

    //}
    //public class Rank
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    [NotMapped, JsonIgnore]
    //    public virtual List<Unit> Units { get; set; }
    //}
    //public class Player
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    [NotMapped, JsonIgnore]
    //    public virtual List<Army> Armies { get; set; }

    //}
    ////Class to hold restrictions, if !null then only specified units, unitTypes, factions osv will have this option
    //public class Restrictions
    //{
    //    public ICollection<Unit> Units { get; set; }
    //    public ICollection<UnitType> UnitTypes { get; set; }
    //    public ICollection<Faction> Factions { get; set; }
    //    public ICollection<Rank> Ranks { get; set; }
    //    public ICollection<UpgradeCategory> UpgradeCategories { get; set; }

    //}


}
