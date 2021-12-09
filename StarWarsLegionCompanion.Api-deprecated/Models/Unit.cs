using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public bool IsUnique { get; set; }
        public int FactionId { get; set; }
        [NotMapped]
        public virtual Faction Faction { get; set; }
        public int RankId { get; set; }
        [NotMapped]
        public virtual Rank Rank { get; set; }
        public int UnitTypeId { get; set; }
        [NotMapped]
        public virtual UnitType UnitType { get; set; }
        public int WoundThreshold { get; set; }
        public int Courage { get; set; }
        public int Speed { get; set; }
        public int MinisInUnit { get; set; }
        public int PointCost { get; set; }
        public bool IsDefenseRed { get; set; }
        public bool IsDefenseSurge { get; set; }
        public int AttackSurgeId { get; set; }
        [NotMapped]
        public virtual AttackSurge AttackSurge { get; set; }
        public int? ArmyId { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; } = new List<Keyword>(); // For many-to-any relations
        public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>(); // For many-to-any relations
        public virtual ICollection<UpgradeCategory> UpgradeCategories { get; set; } = new List<UpgradeCategory>(); // For many-to-any relations

    }
}
