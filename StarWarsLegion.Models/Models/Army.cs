
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    public class Army
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual Player? Player { get; set; }
        public virtual FactionType Faction { get; set; }
        // default to normal battle 800 pts.
        public ArmySetup ArmySetup { get; set; } = new ArmySetup {Id = 1, PointLimit = 800, CommanderMaximum = 2,CommanderMinimum = 1,CorpsMaximum = 6, CorpsMinimum = 3, HeavyMaximum = 2,HeavyMinimum = 0,OperativeMaximum = 2, OperativeMinimum = 0,SpecialForcesMaximum = 3, SpecialForcesMinimum = 0, SupportMaximum = 3, SupportMinimum = 0  };
        public ICollection<ChosenCommand> ChosenCommands { get; set; } = new List<ChosenCommand>();
        public ICollection<ChosenUnit> ChosenUnits { get; set; } = new List<ChosenUnit>();
    }
    public class ArmySetup
    {
        public int Id { get; set; }
        public int PointLimit { get; set; }
        public int CommanderMinimum { get; set; }
        public int CommanderMaximum { get; set; }
        public int OperativeMinimum { get; set; }
        public int OperativeMaximum { get; set; }
        public int CorpsMinimum { get; set; }
        public int CorpsMaximum { get; set; }
        public int SpecialForcesMinimum { get; set; }
        public int SpecialForcesMaximum { get; set; }
        public int SupportMinimum { get; set; }
        public int SupportMaximum { get; set; }
        public int HeavyMinimum { get; set; }
        public int HeavyMaximum { get; set; }

    }

    public class ChosenUnit
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public Unit? Unit { get; set; }
        public ICollection<ChosenUpgrade> ChosenUpgrades { get; set; } = new List<ChosenUpgrade>();
    }
    public class ChosenUpgrade
    {
        public int Id { get; set; }
        public int UpgradeId { get; set; }
        public Upgrade? Upgrade { get; set; }

    }
    public class ChosenCommand
    {
        public int Id { get; set; }
        public int CommandId { get; set; }
        public Command? Command { get; set; }
    }
}
