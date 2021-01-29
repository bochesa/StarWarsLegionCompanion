using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsLegionCompanion.Api.Models
{
    public class Upgrade
    {
        //var forcepush = new Upgrade
        //{
        //    Id = 1,
        //    Name = "Force Push",
        //    Text = "Choose an enemy trooper unit at range 1. Perform a speed-1 move with that unit, even if it is engaged.",
        //    IsExhausable = true,
        //    IsFreeAction = true,
        //    PointCost = 10,
        //    UpgradeCategoryId = 5
        //};
        public int Id { get; set; }
        public string Name { get; set; }
        public int PointCost { get; set; }
        public string Text { get; set; }
        public int? WoundThreshold { get; set; }
        public bool IsExhaustable { get; set; }
        public bool IsFreeAction { get; set; }
        public int UpgradeCategoryId { get; set; }
        public int WeaponId { get; set; }
        [NotMapped]
        public virtual UpgradeCategory UpgradeCategory { get; set; }
        [NotMapped]
        public virtual Weapon Weapon { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; } = new List<Keyword>();
    }

    public class UpgradeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UpgradeId { get; set; }
        public virtual Upgrade Upgrade { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
