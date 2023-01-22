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
                var newlist = upgrades.Where(u => u.UpgradeType == chosenUnitUpgradeModel.UpgradeType).ToList();

                var faction = ArmyModel.ChosenUnits.Where(u => u.Id == chosenUnitUpgradeModel.ChosenUnitId).FirstOrDefault().Unit.Faction.ToString();

                Restriction restriction = new Restriction { RestrictionText = faction };
                var currentUnitId = chosenUnitUpgradeModel.ChosenUnitId;
                var currentUpgradeOptionId = chosenUnitUpgradeModel.ChosenUpgradeOptionId;

                //Get upgrade by id
                foreach (var upgrade in newlist)
                {
                    bool notRestricted = upgrade.Restrictions.Contains(restriction) || upgrade.Restrictions.Count == 0;

                    var testList = armyModel.ChosenUpgrades.Where(u => u.ChosenUnitId == currentUnitId).ToList();
                    var temp = testList.Where(u => u.Upgrade != null && u.Upgrade.Id == upgrade.Id).Count();

                    if (notRestricted && temp == 0)
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
