using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    public enum FactionType
    {
        Rebel,
        Empire,
        [Display(Name = "Separatist Alliance")] SeparatistAlliance,
        [Display(Name = "Galactic Republic ")] GalacticRepublic
    }
    public enum RangeType { Melee, Ranged }
    public enum DefenseDie { white, red }
    //public enum AttackDieType { white, black, red }
    public enum UpgradeType
    {
        none,
        Armament,
        Command,
        Comms,
        Crew,
        Force,
        Gear,
        Generator,
        Grenades,
        Hardpoint,
        HeavyWeapon,
        Ordnance,
        Personnel,
        Pilot,
        Training
    }
    public enum AttackSurge { none, hit, CriticalHit }
    public enum UnitType { Trooper, RepulsorVehicle, GroundVehicle, EmplacementTrooper, CreatureTropper, WookieTropper, DroidTrooper, CloneTrooper }
    public enum RankType { Commander, Operative, Corps, SpecialForces, Support, Heavy }
    public enum ActionType { none, FreeAction, CardAction }

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
