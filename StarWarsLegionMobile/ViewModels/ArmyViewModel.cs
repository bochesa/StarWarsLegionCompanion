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

namespace StarWarsLegionMobile.ViewModels
{
    [QueryProperty(nameof(faction), "faction")]
    public partial class ArmyViewModel : BaseViewModel, IRecipient<UpdateArmyBuilderList>, IRecipient<UpdateArmyFaction>
    {

        [ObservableProperty]
        ArmyModel army;

        [ObservableProperty]
        string armyListName;

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
        ObservableCollection<UnitModel> chosenUnitModels = new();

        [ObservableProperty]
        ObservableCollection<UpgradeModel> chosenUpgradeModels = new();

        [ObservableProperty]
        string faction;

        [ObservableProperty]
        UnitModel selectedItem;
        
        [ObservableProperty]
        Upgrade selectedUpgrade;

        [ObservableProperty]
        string testBinding;

        public ArmyViewModel()
        {
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
                chosenUnitModels.Clear();
                if(army.ChosenUnits.Count > 0)
                {
                    foreach (var chosenUnit in army.ChosenUnits)
                    {
                        UnitModel temp = (UnitModel)chosenUnit.Unit;
                        temp.ChosenId = chosenUnit.Id;
                        chosenUnitModels.Add(temp);
                    }
                }
                chosenUpgradeModels.Clear();
                if(army.ChosenUpgrades.Count > 0)
                {
                    foreach (var upgrade in army.ChosenUpgrades)
                    {
                        chosenUpgradeModels.Add((UpgradeModel)upgrade.Upgrade);
                    }
                }
                Commanders = chosenUnitModels.Where(u => u.Rank == RankType.Commander).Count();
                Operatives = chosenUnitModels.Where(u => u.Rank == RankType.Operative).Count();
                Corps = chosenUnitModels.Where(u => u.Rank == RankType.Corps).Count();
                SpecialForces = chosenUnitModels.Where(u => u.Rank == RankType.SpecialForces).Count();
                Supports = chosenUnitModels.Where(u => u.Rank == RankType.Support).Count();
                Heavies = chosenUnitModels.Where(u => u.Rank == RankType.Heavy).Count();
                ArmyPoints = 0;
                ArmyPoints += chosenUnitModels.Sum(u => u.PointCost);
                ArmyPoints += chosenUpgradeModels.Sum(u => u.PointCost);
                Army.Activations = commanders + operatives + corps + specialForces + supports + heavies;
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
        async Task PickUpgrade(UnitModel unitModel)
        {

            if (unitModel == null) return;
            var armyModel = Army;
            //await Task.Delay(1);
            await Shell.Current.GoToAsync($"{nameof(PickUpgradePage)}", true,
                new Dictionary<string, object>
                {
                    {
                        "ArmyModel",armyModel
                    },
                    {"UnitModel", unitModel }
                });
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
            var unitToRemove = army.ChosenUnits.Where(u => u.Unit.Id == id).First();
            removeUpgrades(unitToRemove);
            army.ChosenUnits.Remove(unitToRemove);

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
            // Save armylist to database
            //TODO to be implemented
           await Shell.Current.DisplayAlert("Save", $"Saving {army.Name} to Database! - Needs implementing", "OK");
        }


    }
}