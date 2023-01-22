using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UtilityLibrary.Models
{
    public class UpgradeOption
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("upgradeType")]
        public UpgradeType UpgradeType { get; set; }
        public int UpgradeOptionId { get; set; }
        [JsonPropertyName("unitId")]
        public int UnitId { get; set; }
    }
}
