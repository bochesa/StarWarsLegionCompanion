using CommunityToolkit.Mvvm.Messaging;
using Newtonsoft.Json.Linq;
using StarWarsLegionMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.ViewModels
{
    [QueryProperty("Army", "Army")]
    public partial class ArmyViewModel : BaseViewModel
    {
        [ObservableProperty]
        int armypoints = 0;
        [ObservableProperty]
        int commanders = 0;
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


        public ArmyViewModel()
        {
            if(Army is null)
            {
                Army = new Army();
            }
                MessagingCenter.Subscribe<WeakReferenceMessenger>(this, "UpdateArmyList", (s) => {
                    commanders = army.ChosenUnits.Where(u=>u.Rank==RankType.Commander).Count();
                    operatives = army.ChosenUnits.Where(u => u.Rank == RankType.Operative).Count();
                    corps= army.ChosenUnits.Where(u => u.Rank == RankType.Corps).Count();
                    specialForces= army.ChosenUnits.Where(u => u.Rank == RankType.SpecialForces).Count();
                    supports = army.ChosenUnits.Where(u => u.Rank == RankType.Support).Count();
                    heavies= army.ChosenUnits.Where(u => u.Rank == RankType.Heavy).Count();
                    armypoints = army.ChosenUnits.Sum(u => u.Unit.PointCost);
                });
            
        }



        [RelayCommand]
        async Task GotoUnitPick(Army army)
        {
            if (army is null) return;

            await Shell.Current.GoToAsync($"{nameof(TestPage)}", true,
                new Dictionary<string, object>
                {
                    {
                        "Army",army
                    }
                });
        }

    }
}
