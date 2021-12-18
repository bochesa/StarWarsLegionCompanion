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
        Neutral,
        [Display(Name = "Rebel Alliance")] Rebel,
        [Display(Name = "Galactic Empire")] Empire,
        [Display(Name = "Separatist Alliance")] Separatist,
        [Display(Name = "Galactic Republic ")] Republic
    }
    public enum RangeType
    {
        Melee = 1,
        Ranged
    }
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
    public enum AttackSurge
    {
        none,
        hit,
        CriticalHit
    }
    public enum UnitType
    {
        Trooper = 1,
        [Display(Name = "Repulsor Vehicle")] RepulsorVehicle,
        [Display(Name = "Ground Vehicle")] GroundVehicle,
        [Display(Name = "Emplacement Vehicle")] EmplacementTrooper,
        [Display(Name = "Createure Vehicle")] CreatureTropper,
        [Display(Name = "Wookie Vehicle")] WookieTropper,
        [Display(Name = "Droid Vehicle")] DroidTrooper,
        [Display(Name = "Clone Vehicle")] CloneTrooper
    }
    public enum RankType
    {
        Commander = 1,
        Operative,
        Corps,
        [Display(Name = "Special Forces")] SpecialForces,
        Support,
        Heavy
    }
    public enum ActionType
    {
        none,
        FreeAction,
        CardAction
    }

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
