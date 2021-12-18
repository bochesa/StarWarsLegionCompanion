using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UtilityLibrary.Models
{
    public class Upgrade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsUnique { get; set; }
        public int PointCost { get; set; }
        public string Restriction { get; set; }
        public string Text { get; set; }
        public int? WoundThreshold { get; set; }
        public bool IsExhaustable { get; set; } = false;
        public bool IsFreeAction { get; set; } = false;
        public Upgrade Reconfigure { get; set; } = null;
        public virtual UpgradeType UpgradeType { get; set; }
        public virtual Weapon Weapon { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}
