using StarWarsLegionMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLegionMobile.ViewModels
{
    [QueryProperty("ArmyModel", "ArmyModel")]
    [QueryProperty("UnitModel", "UnitModel")]
    public partial class PickUpgradeViewModel : BaseViewModel
    {
        DatabaseServices databaseServices;

        public PickUpgradeViewModel(DatabaseServices databaseServices)
        {
            Title = "Pick the Upgrades";
            this.databaseServices = databaseServices;
        }

        [ObservableProperty]
        ArmyModel armyModel;

        [ObservableProperty]
        UnitModel unitModel;

        public ObservableCollection<UpgradeGroup> UpgradesList { get; } = new();

        [RelayCommand]
        async Task AddUpgrade(UpgradeModel upgradeModel)
        {
            //I Need the specific unit aswell
        }

        [RelayCommand]
        async Task GetUpgrades()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var upgrades = await databaseServices.GetUpgradesLocally();
                List<UpgradeModel> force = new();
                var upgradesGrouped = upgrades.GroupBy(x => x.UpgradeType.ToString())
                    .Select(grp=>grp.ToList()).ToList();

                //var keywords = await databaseServices.GetUnits();
                var faction = UnitModel.Faction.ToString();
                var unitType = UnitModel.UnitType;
                var rankType = UnitModel.Rank.ToString();
                if (UpgradesList.Count != 0)
                {
                    UpgradesList.Clear();
                }

                foreach(var option in UnitModel.UpgradeOptions)
                {
                    List<UpgradeModel> temp = new();
                    var newList = upgradesGrouped
                        .SelectMany(u=>u
                        .Where(i=>i.UpgradeType == option.UpgradeType)).ToList();
                     foreach (var upgrade in newList)
                    {
                        if(upgrade.Restrictions.Contains(faction) || upgrade.Restrictions.Count == 0)
                            temp.Add(upgrade);
                    }
                    UpgradesList.Add(new UpgradeGroup(option.UpgradeType.ToString(), temp));
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get upgrade: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}

public class Grouping<T1, T2>
{
    private UpgradeType key;
    private IGrouping<UpgradeType, Upgrade> group;

    public Grouping(UpgradeType key, IGrouping<UpgradeType, Upgrade> group)
    {
        this.key = key;
        this.group = group;
    }
}
