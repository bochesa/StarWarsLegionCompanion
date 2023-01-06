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
        [ObservableProperty]
        Army army;

        public MainViewModel(DatabaseServices databaseServices)
        { 
            this.databaseServices = databaseServices;
            army = new Army { Name = "No Name" };
        }

        [RelayCommand]
        async Task GoToArmyBuilderAsync(Army army)
        {
            if (army is null) return;

            army.Faction = FactionType.Empire;

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

