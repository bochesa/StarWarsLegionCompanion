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
        string faction;

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
                foreach (var unit in army.ChosenUnits)
                {
                    chosenUnitModels.Add((UnitModel)unit.Unit);
                }
                Commanders = chosenUnitModels.Where(u => u.Rank == RankType.Commander).Count();
                Operatives = chosenUnitModels.Where(u => u.Rank == RankType.Operative).Count();
                Corps = chosenUnitModels.Where(u => u.Rank == RankType.Corps).Count();
                SpecialForces = chosenUnitModels.Where(u => u.Rank == RankType.SpecialForces).Count();
                Supports = chosenUnitModels.Where(u => u.Rank == RankType.Support).Count();
                Heavies = chosenUnitModels.Where(u => u.Rank == RankType.Heavy).Count();
                ArmyPoints = chosenUnitModels.Sum(u => u.PointCost);
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
        async Task PickUpgrade(ArmyModel armyModel)
        {
            if (armyModel == null) return; 
            // DETVIRKER!!!
            var faction = armyModel.Faction;
            await Task.Delay(1);
        }


        [RelayCommand]
        async Task GotoUnitPick(ArmyModel armyModel)
        {
            if (armyModel is null) return;

            await Shell.Current.GoToAsync($"{nameof(PickUnitPage)}", true,
                new Dictionary<string, object>
                {
                    {
                        "ArmyModel",armyModel
                    }
                });
        }

        [RelayCommand]
        void RemoveUnit(int id)
        {
            var unitToRemove = army.ChosenUnits.Where(u => u.Unit.Id == id).First();
            army.ChosenUnits.Remove(unitToRemove);

            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(army));
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