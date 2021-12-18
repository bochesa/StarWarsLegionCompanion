
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    public class Army
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Player Player { get; set; }
        public virtual FactionType Faction { get; set; }
        public int PointLimit { get; set; }
        public List<int> CommandIds { get; set; }
        public List<int> UnitIds { get; set; }
        public List<int> UpgradeIds { get; set; }
    }
}
