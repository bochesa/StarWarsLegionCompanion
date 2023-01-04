using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    [Serializable]
    public class Keyword
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonProperty("keywordType")]
        [JsonPropertyName("keywordType")]
        public KeywordType KeywordType { get; set; }

        //public string FullName
        //{
        //    get
        //    {
        //        if (AbilityValue != null)
        //        {
        //            return $"{Name} {AbilityValue}";
        //        }
        //        else return Name;
        //    }
        //}

        [JsonProperty("abilityValue")]
        [JsonPropertyName("abilityValue")]
        public int AbilityValue { get; set; }
        [JsonProperty("shortDescription")]
        [JsonPropertyName("shortDescription")]
        public string? ShortDescription { get; set; }
        [JsonProperty("longDescription")]
        [JsonPropertyName("longDescription")]
        public string? LongDescription { get; set; }
        [JsonProperty("actionType")]
        [JsonPropertyName("actionType")]
        public ActionType ActionType { get; set; }
        [NotMapped]
        public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
        public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
        public virtual ICollection<Upgrade> Upgrades { get; set; } = new List<Upgrade>();
    }
}
