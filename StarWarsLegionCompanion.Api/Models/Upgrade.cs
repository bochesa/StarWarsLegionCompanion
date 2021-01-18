using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class Upgrade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public bool IsUnique { get; set; }
        public int? WoundThreshold { get; set; }
        public string Text { get; set; }
        public int PointCost { get; set; }
        public bool DiscardedAfterUse { get; set; }
        public bool IsExhausable { get; set; }
        public bool IsFreeAction { get; set; }
        public bool IsCardAction { get; set; }
        public int UpgradeCategoryId { get; set; }
                public virtual UpgradeCategory UpgradeCategory { get; set; }
        public int WeaponId { get; set; }
        
        public virtual Weapon Weapon { get; set; }
        public List<Restriction> Restrictions { get; set; } = new List<Restriction>();
        public List<Keyword> Keywords { get; set; } = new List<Keyword>();
        public List<Faction> Factions { get; set; } = new List<Faction>();

    }
}
