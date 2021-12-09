using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string FullName
        {
            get
            {
                if (AbilityValue != null)
                {
                    return $"{Name} {AbilityValue}";
                }
                else return Name;
            }
        }
        public int? AbilityValue { get; set; }
        public string Text { get; set; }
        public bool IsFreeAction { get; set; }
        public bool IsCardAction { get; set; }
        [NotMapped, JsonIgnore]
        public virtual ICollection<Unit> Units { get; set; } = new List<Unit>(); // For many-to-any relations
        [NotMapped, JsonIgnore]
        public virtual ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
        [NotMapped, JsonIgnore]
        public virtual ICollection<Upgrade> Upgrades { get; set; } = new List<Upgrade>();
    }
}
