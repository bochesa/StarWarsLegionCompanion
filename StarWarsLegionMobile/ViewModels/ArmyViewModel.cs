using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Messaging;
using Newtonsoft.Json.Linq;
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
    [QueryProperty(nameof(faction), "faction")]
    public partial class ArmyViewModel : BaseViewModel, IRecipient<UpdateArmyBuilderList>, IRecipient<UpdateArmyFaction>
    {
        DatabaseServices databaseServices;
        [ObservableProperty]
        ArmyModel army;

        [ObservableProperty]
        string armyListName;
        [ObservableProperty]
        int activations;
        [ObservableProperty]
        int commanders;
        [ObservableProperty]
        int operatives;
        [ObservableProperty]
        int corps;
        [ObservableProperty]
        int specialForces;
        [ObservableProperty]
        int supports;
        [ObservableProperty]
        int heavies;
        [ObservableProperty]
        int armyPoints;

        [ObservableProperty]
        ObservableCollection<ChosenUnitModel> chosenUnitModels = new();

        [ObservableProperty]
        string faction;

        public ArmyViewModel(DatabaseServices databaseServices)
        {
            this.databaseServices = databaseServices;
            if (army is null) army = new();
           
            armyListName = "Untitled";
            Title = ArmyListName;
            Faction = "Neutral";

            WeakReferenceMessenger.Default.Register<UpdateArmyBuilderList>(this);
            WeakReferenceMessenger.Default.Register<UpdateArmyFaction>(this);
        }

        public void Receive(UpdateArmyFaction message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Faction = message.Value;
                army.Faction = (FactionType)Enum.Parse(typeof(FactionType), message.Value);
            });
        }

        public void Receive(UpdateArmyBuilderList message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var armyChosenUpgrades = army.ChosenUpgrades;
                List<ChosenUnitUpgradeModel> testList = new();
                foreach (var test in ChosenUnitModels)
                {
                    foreach (var test2 in test.ChosenUnitUpgrades)
                    {
                        testList.Add(test2);
                    }
                }
                ChosenUnitModels.Clear();
                foreach (var unit in Army.ChosenUnits)
                {
                    var chosenUnit = new ChosenUnitModel();
                    chosenUnit.ChosenUnitId = unit.Id;
                    chosenUnit.UnitReference = unit.Unit;
                    if(Army.ChosenUpgrades.Count() > 0)
                    {
                        var upgrades = Army.ChosenUpgrades.Where(cu => cu.ChosenUnitId == unit.Id).ToList();

                        foreach (var upgrade in upgrades)
                        {
                            ChosenUnitUpgradeModel tempUpgrade = new();
                            tempUpgrade.UpgradeType = upgrade.UpgradeType;
                            tempUpgrade.ChosenUnitId = chosenUnit.ChosenUnitId;
                            tempUpgrade.ChosenUpgradeOptionId = upgrade.ChosenUpgradeOption;
                            tempUpgrade.UpgradeReference = upgrade.Upgrade;
                            if(tempUpgrade.UpgradeReference != null)
                            {
                                tempUpgrade.IsUpgraded= true;
                            }
                            chosenUnit.ChosenUnitUpgrades.Add(tempUpgrade);
                        }
                        chosenUnit.ChosenUnitUpgrades = chosenUnit.ChosenUnitUpgrades.OrderBy(u => u.ChosenUpgradeOptionId).ToObservableCollection();
                    }
                        ChosenUnitModels.Add(chosenUnit);

                }
                
                Commanders = chosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Commander).Count();
                Operatives = chosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Operative).Count();
                Corps = chosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Corps).Count();
                SpecialForces = chosenUnitModels.Where(u => u.UnitReference.Rank == RankType.SpecialForces).Count();
                Supports = chosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Support).Count();
                Heavies = chosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Heavy).Count();
                ArmyPoints = 0;
                ArmyPoints += chosenUnitModels.Sum(u => u.UnitReference.PointCost);
                foreach (var unit in chosenUnitModels)
                {
                    foreach (var upgrade in unit.ChosenUnitUpgrades.Where(u=>u.UpgradeReference != null))
                    {
                        ArmyPoints += upgrade.UpgradeReference.PointCost;
                    }
                }
                //ArmyPoints += chosenUnitModels.Sum(um => um.ChosenUpgrades.Where(u => u.Upgrade != null);
                //ArmyPoints += army.ChosenUpgradeModels.Where(m=>m.Upgrade != null ).Sum(u =>  u.Upgrade.PointCost);
                Activations = commanders + operatives + corps + specialForces + supports + heavies;
            });
        }

        [RelayCommand]
        async Task ChangeArmyListName(string input)
        {
            // set name to Army data model
            Army.Name = input;
            await Task.Delay(1);
        }


        [RelayCommand]
        async Task PickOneUpgrade(ChosenUnitUpgradeModel chosenUnitUpgradeModel)
        {
            //set the armymodel value for reference on Pick Upgrade site.
            var armyModel = Army;

            //Remove upgrade from backend List if there is alresy a value set
            var ChosenUpgrades = Army.ChosenUpgrades.ToList();
            var test = ChosenUpgrades.Find(u=>u.ChosenUnitId == chosenUnitUpgradeModel.ChosenUnitId && u.ChosenUpgradeOption == chosenUnitUpgradeModel.ChosenUpgradeOptionId);
            if(test.Upgrade != null) 
            {
                test.Upgrade = null;
                
            }

            //Go to Pick Upgrade site
            await Shell.Current.GoToAsync($"{nameof(PickOneUpgradePage)}", true,
                new Dictionary<string, object>
                {
                    {
                        "ArmyModel", armyModel
                    },
                    {"ChosenUnitUpgradeModel", chosenUnitUpgradeModel }
                });
        }

        [RelayCommand]
        async Task Refresh()
        {

        }

        [RelayCommand]
        async Task GotoUnitPick(string rankType)
        {
            if (string.IsNullOrEmpty(rankType)) return;
            var armyModel = Army;

            await Shell.Current.GoToAsync($"{nameof(PickUnitPage)}", true,
                new Dictionary<string, object>
                {
                    {
                        "ArmyModel", armyModel
                    },
                    {
                        "RankType", rankType
                    }
                });
        }

        [RelayCommand]
        void RemoveUnit(int id)
        {
            var unitToRemove = army.ChosenUnits.Where(u => u.Id == id).First();
            removeUpgrades(unitToRemove);
            army.ChosenUnits.Remove(unitToRemove);

            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(army));
        }

        [RelayCommand]
        async Task RemoveOneUpgrade(ChosenUnitUpgradeModel chosenUpgradeModel)
        {
            var upgradeToRemove = army.ChosenUpgrades.
                Where(u => u.ChosenUnitId == chosenUpgradeModel.ChosenUnitId
                && u.ChosenUpgradeOption == chosenUpgradeModel.ChosenUpgradeOptionId)
                .FirstOrDefault();
            army.ChosenUpgrades.Remove(upgradeToRemove);

            ChosenUpgrade armyUpgrade = new();
            armyUpgrade.Upgrade = null;
            armyUpgrade.UpgradeType = chosenUpgradeModel.UpgradeType;
            armyUpgrade.ChosenUnitId = chosenUpgradeModel.ChosenUnitId;
            armyUpgrade.ChosenUpgradeOption = chosenUpgradeModel.ChosenUpgradeOptionId;

            army.ChosenUpgrades.Add(armyUpgrade);

            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(army));
        }

        private void removeUpgrades(ChosenUnit unit)
        {
            var upgrades = army.ChosenUpgrades.Where(u=>u.ChosenUnitId == unit.Id).ToList();

            foreach (var upgrade in upgrades) 
            {
                army.ChosenUpgrades.Remove(upgrade);
            }
        }

        [RelayCommand]
        async Task SaveArmyList(Army army)
        {
            databaseServices.PostArmy((ArmyModel)army);
            // Save armylist to database
            //TODO to be implemented
           await Shell.Current.DisplayAlert("Save", $"Saving {army.Name} to Database! - Needs implementing", "OK");
        }


    }
}