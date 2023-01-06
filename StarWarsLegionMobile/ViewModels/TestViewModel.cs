using CommunityToolkit.Mvvm.Messaging;
using StarWarsLegionMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.ViewModels
{
    [QueryProperty("Army", "Army")]
    public partial class TestViewModel: BaseViewModel
    {
        int count = 10;

        [ObservableProperty]
        Army army;


        [RelayCommand]
        async Task GoBack(Army army)
        {
            // Note!: Convert this to a selctor of units, and pass the unit in the GoBack method
            Unit actualUnit = new Unit() { Id = 1, Rank = RankType.Corps, PointCost = 40 };
            ChosenUnit newunit= new ChosenUnit { Id = 0, Unit = actualUnit };
            count++;
            army.Name = army.Name + count.ToString();
            newunit.Id = count;
            
            army.ChosenUnits.Add(newunit);

            MessagingCenter.Send(new WeakReferenceMessenger(), "UpdateArmyList");
            
            await Shell.Current.GoToAsync(nameof(ArmyBuilderPage),true, new Dictionary<string,object>
            {
                {
                    "Army", army
                }
            });
        }
    }

}
