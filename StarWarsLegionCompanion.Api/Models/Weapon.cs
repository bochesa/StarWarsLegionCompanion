using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RangeTypeId { get; set; }
        [NotMapped]
        public virtual RangeType RangeType { get; set; }
        public int? MinRange { get; set; }
        public int? MaxRange { get; set; }
        public virtual ICollection<AttackDie> AttackDie { get; set; } = new List<AttackDie>();
        public virtual ICollection<Keyword> Keywords { get; set; } = new List<Keyword>();
        public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
    }

}
