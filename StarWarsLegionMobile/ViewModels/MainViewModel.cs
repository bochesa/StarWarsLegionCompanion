using StarWarsLegionMobile.Services;
using StarWarsLegionMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace StarWarsLegionMobile.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {

        DatabaseServices databaseServices;
        public Army Army { get; set; }

        public MainViewModel(DatabaseServices databaseServices)
        {
            Title = "Army Builder"; 
            this.databaseServices = databaseServices;
            Army = new Army { Name = "test" };
        }

        [RelayCommand]
        async Task GoToArmyBuilderAsync(Army army)
        {
            if (army is null) return;

            army.Faction = FactionType.Empire;
            army.ArmySetup.PointLimit = 800;

            await Shell.Current.GoToAsync($"{nameof(ArmyBuilderPage)}", true,
                new Dictionary<string, object>
                {
                    {
                        "Army",army
                    }
                });

        }

    }
}

