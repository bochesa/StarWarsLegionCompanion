using System;
using System.Collections.Generic;
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
        public virtual RangeType RangeType { get; set; }
        public int? MinRange { get; set; }
        public int? MaxRange { get; set; }
        public string AttackValue { get; set; }
        public List<Keyword> Keywords { get; set; } = new List<Keyword>();
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
    
}
