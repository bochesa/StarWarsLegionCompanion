using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace StarWarsLegionMobile.Models
{
    public partial class ChosenUnitModel : ObservableObject
    {
        [ObservableProperty]
        int chosenUnitId;

        public Unit UnitReference{ get; set; }

        [ObservableProperty]
        ObservableCollection<ChosenUnitUpgradeModel> chosenUnitUpgrades = new();
    }

    public partial class ChosenUnitUpgradeModel : ObservableObject
    {
        [ObservableProperty]
        bool isUpgraded;

        [ObservableProperty]
        int chosenUpgradeOptionId;

        [ObservableProperty]
        int chosenUnitId;
        [ObservableProperty]
        UpgradeType upgradeType;
        public Upgrade UpgradeReference { get; set; }



    }
}
