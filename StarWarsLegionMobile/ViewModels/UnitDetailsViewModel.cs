using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.ViewModels
{
    [QueryProperty("UnitModel", "UnitModel")]
    public partial class UnitDetailsViewModel : BaseViewModel
    {
        public UnitDetailsViewModel()
        {

        }
        [ObservableProperty]
        UnitModel unitModel;
    }
}
