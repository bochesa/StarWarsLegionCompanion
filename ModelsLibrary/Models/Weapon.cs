using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RangeType RangeType { get; set; }
        public int? MinRange { get; set; }
        public int? MaxRange { get; set; }
        public virtual AttackSurge AttackSurge { get; set; } = 0;
        public AttackValue AttackValue { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        public virtual ICollection<Unit> Units { get; set; }

    }

}
