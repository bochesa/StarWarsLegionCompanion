using Newtonsoft.Json;
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
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonProperty("surName")]
        [JsonPropertyName("surName")]
        public string? SurName { get; set; }
        [JsonProperty("isUnique")]
        [JsonPropertyName("isUnique")]
        public bool IsUnique { get; set; }
        [JsonProperty("faction")]
        [JsonPropertyName("faction")]
        public virtual FactionType Faction { get; set; }
        [JsonProperty("rank")]
        [JsonPropertyName("rank")]
        public virtual RankType Rank { get; set; }
        public virtual UnitType UnitType { get; set; }
        [JsonProperty("image")]
        [JsonPropertyName("image")]
        public string? Image { get; set; }
        public int WoundThreshold { get; set; }
        public int Courage { get; set; }
        public int Speed { get; set; }
        public int MinisInUnit { get; set; }
        [JsonProperty("pointCost")]
        [JsonPropertyName("pointCost")]
        public int PointCost { get; set; }
        public bool IsDefenseRed { get; set; } = false;
        public bool IsDefenseSurge { get; set; } = false;
        public virtual AttackSurge AttackSurge { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; } = new List<Keyword>();
        public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
        public virtual ICollection<UpgradeOption> UpgradeOptions { get; set; } = new List<UpgradeOption>();

    }
}