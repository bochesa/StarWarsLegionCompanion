using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    public class Restriction
    {
        public int Id { get; set; }
        [JsonPropertyName("restrictionText")]
        public string? RestrictionText { get; set; }
    }
}
