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
        //public int UnitId { get; set; } //for one to many relations
        public List<Unit> Units { get; set; } = new List<Unit>(); // For many-to-any relations
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

    }
}
