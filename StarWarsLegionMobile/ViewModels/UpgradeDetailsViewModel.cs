using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.ViewModels
{
    [QueryProperty("UpgradeModel", "UpgradeModel")]
    public partial class UpgradeDetailsViewModel : BaseViewModel
    {
        public UpgradeDetailsViewModel()
        {

        }
        [ObservableProperty]
        UpgradeModel upgradeModel;
    }
}
