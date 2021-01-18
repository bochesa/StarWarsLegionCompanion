using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName
        {
            get { return $"{Name} {AbilityValue}"; }
        }
        public int? AbilityValue { get; set; }
        public string Text { get; set; }
        public bool IsFreeAction { get; set; }
        public bool IsCardAction { get; set; }
        public List<Unit> Units { get; set; } = new List<Unit>();
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<Upgrade> Upgrades { get; set; } = new List<Upgrade>();


    }
}
