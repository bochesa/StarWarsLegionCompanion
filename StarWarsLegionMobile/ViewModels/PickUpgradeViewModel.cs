using CommunityToolkit.Mvvm.Messaging;
using StarWarsLegionMobile.Messages;
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

        [ObservableProperty]
        UpgradeModel upgradeModel;

        public ObservableCollection<UpgradeGroup> UpgradesList { get; } = new();

        [RelayCommand]
        async Task AddUpgrade(UpgradeModel upgradeModel)
        {
            var unit = upgradeModel.UnitId;
            var option = upgradeModel.UpgradeOptionId;
            ChosenUpgrade chosenUgrade = new ChosenUpgrade { ChosenUnitId= unit, Upgrade = upgradeModel, ChosenUpgradeOption = option };
            armyModel.ChosenUpgrades.Add(chosenUgrade);
            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(armyModel));
            //await Shell.Current.DisplayAlert("test", $"Chosen upgrade for Unit: {unit} and option: {option}", "OK");
            // rearrange upgrade options - remove the chosen upgrade from available choices
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..", true);
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
                var rankType = UnitModel.Rank.ToString();
                if (UpgradesList.Count != 0)
                {
                    UpgradesList.Clear();
                }

                foreach(var option in UnitModel.UpgradeOptions)
                {
                    List<UpgradeModel> temp = new();
                    var newList = upgradesGrouped
                       .SelectMany(u => u
                       .Where(i => i.UpgradeType == option.UpgradeType)).ToList();
                    List<UpgradeModel> newerList = new List<UpgradeModel>(newList.Count());
                    newList.ForEach(u =>
                    {
                        newerList.Add((UpgradeModel)u.Clone());
                    });
                     foreach (var upgrade in newerList)
                    {
                        if (upgrade.Restrictions.Contains(faction) || upgrade.Restrictions.Count == 0)
                        {
                            upgrade.UnitId = unitModel.ChosenId;
                            upgrade.UpgradeOptionId = option.Id;
                            temp.Add(upgrade);
                        }
                    }
                    UpgradeGroup upgGrp = new(option.UpgradeType.ToString(), temp);

                    UpgradesList.Add(upgGrp);
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
