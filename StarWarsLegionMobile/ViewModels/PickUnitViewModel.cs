using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls.Compatibility;
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
    [QueryProperty("Army", "Army")]
    public partial class PickUnitViewModel : BaseViewModel
    {
        DatabaseServices databaseServices;
        public PickUnitViewModel(DatabaseServices databaseServices)
        {
            Title = "Put a title here";
            this.databaseServices = databaseServices;
        }

        [ObservableProperty]
        Army army;

        public ObservableCollection<UnitModel> Unitslist { get; } = new ObservableCollection<UnitModel>();

        [RelayCommand]
        async Task AddUnit(UnitModel unitModel)
        {
            ChosenUnit chosenUnit = new ChosenUnit();
            chosenUnit.Unit = (Unit)unitModel;
            army.ChosenUnits.Add(chosenUnit);
            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(army));
            await GoBack();
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", true);
        }

        [RelayCommand]
        async Task GetUnits()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var units = await databaseServices.GetUnitsLocally();
                //var keywords = await databaseServices.GetUnits();
                if (Unitslist.Count != 0)
                {
                    Unitslist.Clear();
                }

                foreach (var unit in units)
                {
                    if(unit.Faction == Army.Faction)
                    Unitslist.Add(unit);
                }

                if(army.ChosenUnits.Count() != 0)
                {
                    var chosenUniques = army.ChosenUnits.Where(u=>u.Unit.IsUnique).ToList();
                   
                    foreach (var unit in chosenUniques)
                    {
                        var unitid = unit.Unit.Id;
                        var unittoremove = Unitslist.FirstOrDefault(u=>u.Id== unitid);
                        Unitslist.Remove(unittoremove);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get unit: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
