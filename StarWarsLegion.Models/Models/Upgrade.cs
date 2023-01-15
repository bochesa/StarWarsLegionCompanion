using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    [Serializable]
    public class Upgrade
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonProperty("isUnique")]
        [JsonPropertyName("isUnique")]
        public bool IsUnique { get; set; }
        [JsonProperty("pointCost")]
        [JsonPropertyName("pointCost")]
        public int PointCost { get; set; }
        [JsonProperty("restrictions")]
        [JsonPropertyName("restrictions")]
        public List<string>? Restrictions { get; set; } = new List<string>();
        [JsonProperty("text")]
        [JsonPropertyName("text")]
        public string? Text { get; set; }
        [JsonProperty("woundThreshold")]
        [JsonPropertyName("woundThreshold")]
        public int WoundThreshold { get; set; }
        [JsonProperty("isExhaustable")]
        [JsonPropertyName("isExhaustable")]
        public bool IsExhaustable { get; set; } = false;
        [JsonPropertyName("isAction")]
        public bool IsAction { get; set; } = false;
        [JsonProperty("isFreeAction")]
        [JsonPropertyName("isFreeAction")]
        public bool IsFreeAction { get; set; } = false;

        [JsonProperty("image")]
        [JsonPropertyName("image")]
        public string? Image { get; set; }
        public Upgrade? Reconfigure { get; set; } = null;

        [JsonPropertyName("upgradeType")]
        public virtual UpgradeType UpgradeType { get; set; }
        public virtual Weapon? Weapon { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; } = new List<Keyword>();
    }
}
