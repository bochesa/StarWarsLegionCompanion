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
    [QueryProperty("Army", "Army")]
    public partial class ArmyViewModel : BaseViewModel, IRecipient<UpdateArmyBuilderList>
    {

        [ObservableProperty]
        int armypoints;
        [ObservableProperty]
        int commanders;
        [ObservableProperty]
        int operatives = 0;
        [ObservableProperty]
        int corps = 0;
        [ObservableProperty]
        int specialForces = 0;
        [ObservableProperty]
        int supports = 0;
        [ObservableProperty]
        int heavies = 0;

        [ObservableProperty]
        Army army;

        [ObservableProperty]
        ObservableCollection<UnitModel> chosenUnitModels= new ObservableCollection<UnitModel>();

        public ArmyViewModel()
        {
            if(Army is null)
            {
                Army = new Army();
            }

            WeakReferenceMessenger.Default.Register<UpdateArmyBuilderList>(this);
        }


        public void Receive(UpdateArmyBuilderList message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                chosenUnitModels.Clear();
                commanders = message.Value.ChosenUnits.Where(u => u.Unit.Rank == RankType.Commander).Count();
                operatives = message.Value.ChosenUnits.Where(u => u.Unit.Rank == RankType.Operative).Count();
                corps = message.Value.ChosenUnits.Where(u => u.Unit.Rank == RankType.Corps).Count();
                specialForces = message.Value.ChosenUnits.Where(u => u.Unit.Rank == RankType.SpecialForces).Count();
                supports = message.Value.ChosenUnits.Where(u => u.Unit.Rank == RankType.Support).Count();
                heavies = message.Value.ChosenUnits.Where(u => u.Unit.Rank == RankType.Heavy).Count();
                armypoints = message.Value.ChosenUnits.Sum(u => u.Unit.PointCost);
                foreach (var unit in message.Value.ChosenUnits)
                {
                    chosenUnitModels.Add((UnitModel)unit.Unit);
                }
            });
        }

        [RelayCommand]
        async Task GotoUnitPick(Army army)
        {
            if(army is null) return;


            await Shell.Current.GoToAsync($"{nameof(PickUnitPage)}", true,
                new Dictionary<string, object>
                {
                    {
                        "Army",army
                    }
                });
        } 
    }
}
