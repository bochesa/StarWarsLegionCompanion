using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.Application.Handlers
{
    public class WeaponDTO
    {
        public string Name { get; set; }
        public string RangeType { get; set; }
        public int? MinRange { get; set; }
        public int? MaxRange { get; set; }
        public virtual AttackValueDTO AttackValue { get; set; }
        public virtual ICollection<KeywordDTO> Keywords { get; set; }
    }
}
