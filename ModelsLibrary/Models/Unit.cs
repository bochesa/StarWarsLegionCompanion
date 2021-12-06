using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool IsUnique { get; set; }
        public virtual FactionType Faction { get; set; }
        public virtual RankType Rank { get; set; }
        public virtual UnitType UnitType { get; set; }
        public int WoundThreshold { get; set; }
        public int Courage { get; set; }
        public int Speed { get; set; }
        public int MinisInUnit { get; set; }
        public int PointCost { get; set; }
        public bool IsDefenseRed { get; set; }
        public bool IsDefenseSurge { get; set; }
        public virtual AttackSurge AttackSurge { get; set; }
        public int? ArmyId { get; set; }
        public virtual IEnumerable<Keyword> Keywords { get; set; }
        public virtual IEnumerable<Weapon> Weapons { get; set; }
        public virtual IEnumerable<UpgradeType> UpgradeCategories { get; set; }

    }
}