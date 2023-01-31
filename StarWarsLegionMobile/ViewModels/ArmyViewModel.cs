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
    //[QueryProperty(nameof(Faction), "faction")]
    [QueryProperty(nameof(ArmyModel), "ArmyModel")]
    public partial class ArmyViewModel : BaseViewModel, IRecipient<UpdateArmyBuilderList>, IRecipient<UpdateArmyFaction>
    {
        DatabaseServices databaseServices;
        [ObservableProperty]
        ArmyModel armyModel;

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
           
            ArmyListName = "Untitled";
            Faction = "Neutral";

            WeakReferenceMessenger.Default.Register<UpdateArmyBuilderList>(this);
            WeakReferenceMessenger.Default.Register<UpdateArmyFaction>(this);
        }

        public void Receive(UpdateArmyFaction message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Faction = message.Value;
            });
        }

        public void Receive(UpdateArmyBuilderList message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ArmyListName = message.Value.Name;
                Faction = message.Value.Faction.ToString();
                var armyChosenUpgrades = ArmyModel.ChosenUpgrades;
                List<ChosenUnitUpgradeModel> testList = new();
                foreach (var test in ChosenUnitModels)
                {
                    foreach (var test2 in test.ChosenUnitUpgrades)
                    {
                        testList.Add(test2);
                    }
                }
                ChosenUnitModels.Clear();
                foreach (var unit in ArmyModel.ChosenUnits)
                {
                    var chosenUnit = new ChosenUnitModel();
                    chosenUnit.ChosenUnitId = unit.Id;
                    chosenUnit.UnitReference = unit.Unit;
                    chosenUnit.UnitThumb = $"https://image.bochesa.dk/Units/Icons/{Helper.RemoveWhitespace(unit.Unit.Name).ToLower()}.jpeg";
                    if (ArmyModel.ChosenUpgrades.Count() > 0)
                    {
                        var upgrades = ArmyModel.ChosenUpgrades.Where(cu => cu.ChosenUnitId == unit.Id).ToList();

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
                
                Commanders = ChosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Commander).Count();
                Operatives = ChosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Operative).Count();
                Corps = ChosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Corps).Count();
                SpecialForces = ChosenUnitModels.Where(u => u.UnitReference.Rank == RankType.SpecialForces).Count();
                Supports = ChosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Support).Count();
                Heavies = ChosenUnitModels.Where(u => u.UnitReference.Rank == RankType.Heavy).Count();
                ArmyPoints = 0;
                ArmyPoints += ChosenUnitModels.Sum(u => u.UnitReference.PointCost);
                foreach (var unit in ChosenUnitModels)
                {
                    foreach (var upgrade in unit.ChosenUnitUpgrades.Where(u=>u.UpgradeReference != null))
                    {
                        ArmyPoints += upgrade.UpgradeReference.PointCost;
                    }
                }
                Activations = Commanders + Operatives + Corps + SpecialForces + Supports + Heavies;
            });
        }

        [RelayCommand]
        async Task ChangeArmyListName(string input)
        {
            // set name to Army data model
            ArmyModel.Name = input;
            await Task.Delay(1);
        }


        [RelayCommand]
        async Task PickOneUpgrade(ChosenUnitUpgradeModel chosenUnitUpgradeModel)
        {
            //set the armymodel value for reference on Pick Upgrade site.
            var armyModel = ArmyModel;

            //Remove upgrade from backend List if there is alresy a value set
            var ChosenUpgrades = ArmyModel.ChosenUpgrades.ToList();
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
            var armyModel = ArmyModel;

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
            var unitToRemove = ArmyModel.ChosenUnits.Where(u => u.Id == id).First();
            removeUpgrades(unitToRemove);
            ArmyModel.ChosenUnits.Remove(unitToRemove);

            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(ArmyModel));
        }
        [RelayCommand]
        async Task CopyCurrentUnit(int id)
        {

            var unitToCopy = ArmyModel.ChosenUnits.Where(u => u.Id == id).First();
            if (unitToCopy.Unit.IsUnique)
            {
                await Shell.Current.DisplayAlert("Error", "You cannot copy a Unique unit", "OK");
                return;
            }
            AddUnit(id,(UnitModel)unitToCopy.Unit);

            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(ArmyModel));
        }

        void AddUnit(int chosenUnitId, UnitModel unitModel)
        {
            // Get all upgrades for the unit
            ChosenUnitModel chosenUnit = new() { ChosenUnitId = 1 };
            chosenUnit.UnitThumb = unitModel.UnitThumb;
            var unitModelUpgrades = ArmyModel.ChosenUpgrades.Where(u => u.ChosenUnitId == chosenUnitId).ToList();
            
            chosenUnit.UnitReference = (UnitModel)unitModel;

            var options = unitModel.UpgradeOptions.ToList();

            var lastChosenUnit = ArmyModel.ChosenUnits.OrderByDescending(i => i.Id).FirstOrDefault();
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
                var upgrades = unitModelUpgrades.Where(u => u.ChosenUpgradeOption == options[i].Id);
                bool useExsistingUpgrade = upgrades.Any();
                //add frontend upgrade
                if (useExsistingUpgrade)
                {
                    var upgrade = upgrades.First();
                    ChosenUnitUpgradeModel upgradeModel = new ChosenUnitUpgradeModel
                    {
                        ChosenUnitId = armyUnit.Id,
                        IsUpgraded = true,
                        ChosenUpgradeOptionId = upgrade.ChosenUpgradeOption,
                        UpgradeType = upgrade.UpgradeType,
                        UpgradeReference = upgrade.Upgrade
                    };
                    chosenUnit.ChosenUnitUpgrades.Add(upgradeModel);
                }
                else
                {
                    ChosenUnitUpgradeModel tempUpgrade = new();
                    tempUpgrade.IsUpgraded = false;
                    tempUpgrade.UpgradeType = options[i].UpgradeType;
                    tempUpgrade.ChosenUnitId = chosenUnit.ChosenUnitId;
                    tempUpgrade.ChosenUpgradeOptionId = options[i].Id;
                    tempUpgrade.UpgradeReference = null;
                    chosenUnit.ChosenUnitUpgrades.Add(tempUpgrade);

                }

                //add backend upgrade
                if (useExsistingUpgrade)
                {
                    var upgrade = upgrades.First();
                    ChosenUpgrade armyUpgrade = new ChosenUpgrade
                    {
                        UpgradeType = upgrade.UpgradeType,
                        ChosenUnitId = armyUnit.Id,
                        ChosenUpgradeOption = upgrade.ChosenUpgradeOption,
                        Upgrade = upgrade.Upgrade,
                    };
                    ArmyModel.ChosenUpgrades.Add(armyUpgrade);

                }
                else
                {
                    ChosenUpgrade armyUpgrade = new();
                    armyUpgrade.Upgrade = null;
                    armyUpgrade.UpgradeType = options[i].UpgradeType;
                    armyUpgrade.ChosenUnitId = chosenUnit.ChosenUnitId;
                    armyUpgrade.ChosenUpgradeOption = options[i].Id;
                    ArmyModel.ChosenUpgrades.Add(armyUpgrade);

                }

            };

            //add backend unit
            ArmyModel.ChosenUnits.Add(armyUnit);

        }

        [RelayCommand]
        async Task RemoveOneUpgrade(ChosenUnitUpgradeModel chosenUpgradeModel)
        {
            var upgradeToRemove = ArmyModel.ChosenUpgrades.
                Where(u => u.ChosenUnitId == chosenUpgradeModel.ChosenUnitId
                && u.ChosenUpgradeOption == chosenUpgradeModel.ChosenUpgradeOptionId)
                .FirstOrDefault();
            ArmyModel.ChosenUpgrades.Remove(upgradeToRemove);

            ChosenUpgrade armyUpgrade = new();
            armyUpgrade.Upgrade = null;
            armyUpgrade.UpgradeType = chosenUpgradeModel.UpgradeType;
            armyUpgrade.ChosenUnitId = chosenUpgradeModel.ChosenUnitId;
            armyUpgrade.ChosenUpgradeOption = chosenUpgradeModel.ChosenUpgradeOptionId;

            ArmyModel.ChosenUpgrades.Add(armyUpgrade);

            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(ArmyModel));
        }

        private void removeUpgrades(ChosenUnit unit)
        {
            var upgrades = ArmyModel.ChosenUpgrades.Where(u=>u.ChosenUnitId == unit.Id).ToList();

            foreach (var upgrade in upgrades) 
            {
                ArmyModel.ChosenUpgrades.Remove(upgrade);
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