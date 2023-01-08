using CommunityToolkit.Mvvm.Messaging;
using StarWarsLegionMobile.Messages;
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
        
        public MainViewModel(DatabaseServices databaseServices)
        { 
            this.databaseServices = databaseServices;
        }

        [RelayCommand]
        async Task GoToArmyBuilderAsync(string faction)
        {

            //army.Faction = (FactionType)Enum.Parse(typeof(FactionType), faction);

            await Shell.Current.GoToAsync($"{nameof(ArmyBuilderPage)}?faction={faction}", true);
            WeakReferenceMessenger.Default.Send(new UpdateArmyFaction(faction));

        }

    }
}

