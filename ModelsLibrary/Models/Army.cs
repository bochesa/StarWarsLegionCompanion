
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
        public string Name { get; set; }
        public virtual Player Player { get; set; }
        public virtual FactionType Faction { get; set; }
        public int PointLimit { get; set; }
        public ICollection<ChosenCommand> ChosenCommands { get; set; } = new List<ChosenCommand>();
        public ICollection<ChosenUnit> ChosenUnits { get; set; } = new List<ChosenUnit>();
    }

    public class ChosenUnit
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public ICollection<ChosenUpgrade> ChosenUpgrades { get; set; } = new List<ChosenUpgrade>();
    }
    public class ChosenUpgrade
    {
        public int Id { get; set; }
        public int UpgradeId { get; set; }
        public Upgrade Upgrade { get; set; }

    }
    public class ChosenCommand
    {
        public int Id { get; set; }
        public int CommandId { get; set; }
        public Command Command { get; set; }
    }
}
