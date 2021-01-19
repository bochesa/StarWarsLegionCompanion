using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    //public enum RangeType { Melee, Ranged }
    //public enum FactionType { Rebel, Empire, [Display(Name="Separatist Alliance")]SeparatistAlliance, [Display(Name = "Galactic Republic ")]GalacticRepublic }
    //public enum DefenseDie { white, red }
    //public enum AttackDieType { white, black, red }
    //public enum UpgradeType { Armament, Command, Comms, Crew, Force, Gear, Generator, Grenades, Hardpoint, HeavyWeapon, Ordnance, Personnel, Pilot, Training }
    //public enum AttackSurge { none, hit, CriticalHit}
    //public enum UnitType {Trooper, RepulsorVehicle, GroundVehicle, EmplacementTrooper, CreatureTropper, WookieTropper, DroidTrooper, CloneTrooper}
    //public enum RankType { Commander, Operative, Corps, SpecialForces, Support, Heavy}
  
    public class RangeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
  
    public class AttackSurge
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class UnitType
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Rank
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}
