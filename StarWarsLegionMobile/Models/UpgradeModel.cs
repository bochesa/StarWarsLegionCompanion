using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.Models
{
    public partial class UpgradeModel : Upgrade, ICloneable
    {
        public string UpgradeIcon { get; set; }
        public int UpgradeOptionId { get; set; }
        public int UnitId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class UpgradeGroup : List<UpgradeModel>
    {
        public string UpgradeType { get; private set; }

        public UpgradeGroup(string upgradeType, 
            List<UpgradeModel> upgrades) : base(upgrades)
        {
            UpgradeType = upgradeType;
        }
    }
}
