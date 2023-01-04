using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.ViewModels
{
    [QueryProperty("KeywordModel","KeywordModel")]
    public partial class KeywordDetailsViewModel: BaseViewModel
    {
        public KeywordDetailsViewModel()
        {

        }
        [ObservableProperty]
        KeywordModel keywordModel;
    }
}
