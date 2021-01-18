using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUnique { get; set; }
        public string SurName { get; set; }
        public int FactionId { get; set; }
        public virtual Faction Faction { get; set; }
        public int UnitTypeId { get; set; }
        public virtual UnitType UnitType { get; set; }
        public int RankId { get; set; }
        public virtual Rank Rank { get; set; }
        public byte[] Image { get; set; }
        public int PointCost { get; set; }
        public int WoundThreshold { get; set; }
        public int Courage { get; set; }
        public int Speed { get; set; }
        public int DefenseDieId { get; set; }
        public virtual DefenseDie DefenseDie { get; set; }
        public int AttackSurgeId { get; set; }
        public virtual AttackSurge AttackSurge { get; set; }
        public bool IsDefenseSurge { get; set; }
        public int MinisInUnit { get; set; }
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<Keyword> Keywords { get; set; } = new List<Keyword>();
        public List<UpgradeCategory> UpgradeCategory { get; set; } = new List<UpgradeCategory>();
    }
}
