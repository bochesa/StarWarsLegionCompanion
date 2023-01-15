using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.Models
{
    public partial class UpgradeModel : Upgrade
    {
        public string UpgradeIcon { get; set; }
        public int UpgradeOptionId { get; set; }

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
