using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Layouts;
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
    [QueryProperty("ArmyModel", "ArmyModel")]
    [QueryProperty("RankType", "RankType")]
    public partial class PickUnitViewModel : BaseViewModel
    {
        DatabaseServices databaseServices;
        public PickUnitViewModel(DatabaseServices databaseServices)
        {
            Title = "Put a title here";
            this.databaseServices = databaseServices;
        }

        [ObservableProperty]
        ArmyModel armyModel;

        [ObservableProperty]
        string rankType;

        public ObservableCollection<UnitModel> Unitslist { get; } = new ObservableCollection<UnitModel>();

        [RelayCommand]
        async Task AddUnit(UnitModel unitModel)
        {
            ChosenUnitModel chosenUnit = new () { ChosenUnitId = 1 };
            chosenUnit.UnitThumb = unitModel.UnitThumb;
            chosenUnit.UnitReference = (UnitModel)unitModel;

            var options = unitModel.UpgradeOptions.ToList();

            var lastChosenUnit = armyModel.ChosenUnits.OrderByDescending(i=>i.Id).FirstOrDefault();
            if (lastChosenUnit != null)
            {
                var id = lastChosenUnit.Id;
                if (id > 0)
                {
                    id++;
                }
                chosenUnit.ChosenUnitId = id;
            }

            ChosenUnit armyUnit = new();
            armyUnit.Unit = unitModel;
            armyUnit.UnitId = unitModel.Id;
            armyUnit.Id = chosenUnit.ChosenUnitId;

            for (int i = 0; i < options.Count(); i++)
            {
                //add frontend upgrade
                ChosenUnitUpgradeModel tempUpgrade = new();
                tempUpgrade.IsUpgraded = false;
                tempUpgrade.UpgradeType = options[i].UpgradeType;
                tempUpgrade.ChosenUnitId = chosenUnit.ChosenUnitId;
                tempUpgrade.ChosenUpgradeOptionId = options[i].Id;
                tempUpgrade.UpgradeReference = null;
                chosenUnit.ChosenUnitUpgrades.Add(tempUpgrade);

                //add backend upgrade
                ChosenUpgrade armyUpgrade= new();
                armyUpgrade.Upgrade = null;
                armyUpgrade.UpgradeType = options[i].UpgradeType;
                armyUpgrade.ChosenUnitId= chosenUnit.ChosenUnitId;
                armyUpgrade.ChosenUpgradeOption = options[i].Id;
                armyModel.ChosenUpgrades.Add(armyUpgrade);

            };

            //add backend unit
            armyModel.ChosenUnits.Add(armyUnit);

            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(armyModel));
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
            RankType rankType = (RankType)Enum.Parse(typeof(RankType), RankType);

            try
            {
                IsBusy = true;
                var units = await databaseServices.GetUnitsLocally();
                //var keywords = await databaseServices.GetUnits();
                if (Unitslist.Count != 0)
                {
                    Unitslist.Clear();
                }
                var unitsToShow = units.Where(u=>u.Faction == ArmyModel.Faction && u.Rank == rankType).ToList();
                foreach (var unit in unitsToShow)
                {
                    Unitslist.Add(unit);
                }

                if(armyModel.ChosenUnits.Count() != 0)
                {
                    var chosenUniques = armyModel.ChosenUnits.Where(u=>u.Unit.IsUnique).ToList();
                   
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
