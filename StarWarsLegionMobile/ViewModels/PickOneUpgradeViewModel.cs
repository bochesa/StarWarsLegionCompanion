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
    [QueryProperty("ChosenUnitUpgradeModel", "ChosenUnitUpgradeModel")]
    public partial class PickOneUpgradeViewModel : BaseViewModel
    {
        DatabaseServices databaseServices;
        public PickOneUpgradeViewModel(DatabaseServices databaseServices)
        {
            Title = "Pick One Upgrade";
            this.databaseServices = databaseServices;
        }

        [ObservableProperty]
        ArmyModel armyModel;

        [ObservableProperty]
        ChosenUnitUpgradeModel chosenUnitUpgradeModel;

        public ObservableCollection<UpgradeModel> AvailableUpgradeList { get; } = new();

        [RelayCommand]
        async Task AddUpgrade(UpgradeModel upgradeModel)
        {
            ChosenUnitUpgradeModel.UpgradeReference = upgradeModel;
            ChosenUpgrade chosenUpgrade = new ();
            chosenUpgrade.Upgrade = upgradeModel;
            chosenUpgrade.ChosenUnitId = ChosenUnitUpgradeModel.ChosenUnitId;
            chosenUpgrade.ChosenUpgradeOption = ChosenUnitUpgradeModel.ChosenUpgradeOptionId;
            chosenUpgrade.UpgradeType = upgradeModel.UpgradeType;
            var upgradeToRemove = ArmyModel.ChosenUpgrades.
                Where(u => u.ChosenUnitId == ChosenUnitUpgradeModel.ChosenUnitId 
                && u.ChosenUpgradeOption == ChosenUnitUpgradeModel.ChosenUpgradeOptionId)
                .FirstOrDefault();
            ArmyModel.ChosenUpgrades.Remove(upgradeToRemove);
            ArmyModel.ChosenUpgrades.Add(chosenUpgrade);

            WeakReferenceMessenger.Default.Send(new UpdateArmyBuilderList(ArmyModel));
            await GoBack();
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
                var filteredUpgradesByType = upgrades.Where(u => u.UpgradeType == ChosenUnitUpgradeModel.UpgradeType).ToList();

                var faction = ArmyModel.ChosenUnits.Where(u => u.Id == ChosenUnitUpgradeModel.ChosenUnitId).FirstOrDefault().Unit.Faction.ToString();

                var currentUnitId = ChosenUnitUpgradeModel.ChosenUnitId;
                //var currentUpgradeOptionId = ChosenUnitUpgradeModel.ChosenUpgradeOptionId;

                //Get upgrade by id
                foreach (var upgrade in filteredUpgradesByType)
                {
                    bool notRestricted = true;
                    if (upgrade.Restrictions.Count() != 0)
                    {
                        var restric = upgrade.Restrictions.Where(u => u.RestrictionText == faction).FirstOrDefault();
                        notRestricted = upgrade.Restrictions.Contains(restric);
                    }

                    var ChosenUpgradeOptions = armyModel.ChosenUpgrades.Where(u => u.ChosenUnitId == currentUnitId).ToList();
                    var numberOfExcistingUpgrades = ChosenUpgradeOptions.Where(u => u.Upgrade != null && u.Upgrade.Id == upgrade.Id).Count();

                    if (notRestricted && numberOfExcistingUpgrades == 0)
                    {
                        AvailableUpgradeList.Add(upgrade);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get upgrade by id: id, {ex.Message}", "OK");
            }
            finally { 
                IsBusy= false;
            }

        }
    }
}
