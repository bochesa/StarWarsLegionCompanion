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
    public partial class UpgradeViewModel : BaseViewModel
    {
        DatabaseServices databaseServices;

        public ObservableCollection<UpgradeModel> Upgrades { get; } = new ObservableCollection<UpgradeModel>();
        public UpgradeViewModel(DatabaseServices databaseServices)
        {
            Title = "Upgrades database";
            this.databaseServices= databaseServices;
        }

        [RelayCommand]
        async Task GoToDetailsAsync(UpgradeModel upgradeModel)
        {
            if (upgradeModel is null) return;

            await Shell.Current.GoToAsync($"{nameof(UpgradeDetailsPage)}", true,
                new Dictionary<string, object>
                {
                    {
                        "UpgradeModel",upgradeModel
                    }
                });

        }

        [RelayCommand]
        async Task GetUpgrades()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var upgrades = await databaseServices.GetUpgradesLocally();
                //var keywords = await databaseServices.GetUpgrades();
                if (Upgrades.Count != 0)
                {
                    Upgrades.Clear();
                }
                foreach (var upgrade in upgrades)
                {
                    var upgradeIconName = upgrade.UpgradeType.ToString().ToLower();
                    upgrade.UpgradeIcon = $"https://image.bochesa.dk/UpgradeIcon/{upgradeIconName}.png";
                    Upgrades.Add(upgrade);
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
